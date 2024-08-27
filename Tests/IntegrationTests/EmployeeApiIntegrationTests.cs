using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace EmployeeApi.Tests.IntegrationTests
{
    public class EmployeeApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public EmployeeApiIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllEmployees_ShouldReturnSuccess()
        {
            // Act
            var response = await _client.GetAsync("/api/employee");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateEmployee_ShouldReturnCreated()
        {
            // Arrange
            var newEmployee = new { FirstName = "Sasi", LastName = "Kumar", Department = "Software Developer" };

            // Act
            var response = await _client.PostAsJsonAsync("/api/employee", newEmployee);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
