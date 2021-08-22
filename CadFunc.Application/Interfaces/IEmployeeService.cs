using CadFunc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadFunc.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();
        Task<EmployeeDTO> GetById(int? id);
        Task Add(EmployeeDTO employeeDto);
        Task Update(EmployeeDTO employeeDto);
        Task Remove(int? id);
    }
}
