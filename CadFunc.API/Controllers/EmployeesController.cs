using CadFunc.Application.DTOs;
using CadFunc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadFunc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get()
        {
            var employees = await _employeeService.GetEmployees();
            if (employees == null)
            {
                return NotFound("Employees Not Found");
            }
            return Ok(employees);
        }

        [HttpGet("{id:int}", Name = "GetEmployee")]
        public async Task<ActionResult<EmployeeDTO>> Get(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound("Employee Not Found");
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeeDTO employeeDto)
        {
            if(employeeDto == null)
                return BadRequest("Invalid Data");

            await _employeeService.Add(employeeDto);

            return new CreatedAtRouteResult("GetEmployee", new { id = employeeDto.Id }, employeeDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeeDTO employeeDto)
        {
            if (employeeDto == null)
                return BadRequest();

            if (id != employeeDto.Id)
                return BadRequest();

            var employee = await _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound("Employee Not Found");
            }

            await _employeeService.Update(employeeDto);
            return Ok(employeeDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmployeeDTO>> Delete(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound("Employee Not Found");
            }

            await _employeeService.Remove(id);
            return Ok(employee);
        }
    }
}
