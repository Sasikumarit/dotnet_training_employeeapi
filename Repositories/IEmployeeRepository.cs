using EmployeeApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(string id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(string id);
    }
}
