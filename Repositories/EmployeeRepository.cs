using EmployeeApi.Configuration;
using EmployeeApi.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public EmployeeRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _cosmosClient = cosmosClient;
            var cosmosSettings = configuration.GetSection("CosmosDb").Get<CosmosDbSettings>();
            _container = _cosmosClient.GetContainer(cosmosSettings.DatabaseName, cosmosSettings.ContainerName);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<Employee>();
            var results = new List<Employee>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        public async Task<Employee> GetByIdAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Employee>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException)
            {
                return null;
            }
        }

        public async Task AddAsync(Employee employee)
        {
            employee.Id = Guid.NewGuid().ToString();
            await _container.CreateItemAsync(employee, new PartitionKey(employee.Id));
        }

        public async Task UpdateAsync(Employee employee)
        {
            await _container.UpsertItemAsync(employee, new PartitionKey(employee.Id));
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<Employee>(id, new PartitionKey(id));
        }
    }
}
