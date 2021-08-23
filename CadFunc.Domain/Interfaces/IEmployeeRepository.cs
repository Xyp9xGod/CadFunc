using CadFunc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadFunc.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetByIdAsync(int? id);
        Task<Employee> CreateAsync(Employee employee);
        Task<Employee> UpdateAsync(Employee employee);
        Task<Employee> RemoveAsync(Employee employee);
    }
}
