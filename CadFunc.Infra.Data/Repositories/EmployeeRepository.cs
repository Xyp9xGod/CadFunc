using CadFunc.Domain.Entities;
using CadFunc.Domain.Interfaces;
using CadFunc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadFunc.Infra.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ApplicationDbContext _employeeContext;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _employeeContext = context;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            _employeeContext.Add(employee);
            await _employeeContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> GetByIdAsync(int? id)
        {
            var employee = await _employeeContext.Employees.FindAsync(id);
            if (employee != null) {
                _employeeContext.Entry(employee).State = EntityState.Detached;//evita erro por tracking.
            }

            return employee;
            //return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id); //telefone
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeContext.Employees.ToListAsync();
        }

        public async Task<Employee> RemoveAsync(Employee employee)
        {
            _employeeContext.Remove(employee);
            await _employeeContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            _employeeContext.Update(employee);
            await _employeeContext.SaveChangesAsync();
            return employee;
        }
    }
}
