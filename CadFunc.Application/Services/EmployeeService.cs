using AutoMapper;
using CadFunc.Application.DTOs;
using CadFunc.Application.Interfaces;
using CadFunc.Domain.Entities;
using CadFunc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadFunc.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ??
                 throw new ArgumentNullException(nameof(employeeRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            var employeesEntity = await _employeeRepository.GetEmployeesAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employeesEntity);
        }

        public async Task<EmployeeDTO> GetById(int? id)
        {
            var employeeEntity = await _employeeRepository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDTO>(employeeEntity);
        }

        public async Task Add(EmployeeDTO employeeDto)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.CreateAsync(employeeEntity);
        }

        public async Task Update(EmployeeDTO employeeDto)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.UpdateAsync(employeeEntity);
        }

        public async Task Remove(int? id)
        {
            var employeeEntity = _employeeRepository.GetByIdAsync(id).Result;
            await _employeeRepository.RemoveAsync(employeeEntity);
        }
    }
}
