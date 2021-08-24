using Microsoft.Extensions.Configuration;
using CadFunc.Application.DTOs;
using CadFunc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using CadFunc.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;

namespace CadFunc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;
        private readonly IConfiguration _configuration;
        public EmployeesController(IEmployeeService employeeService, IConfiguration configuration)
        {
            _employeeService = employeeService;
            _configuration = configuration;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get()
        {
            var employees = await _employeeService.GetEmployees();
            if (employees == null)
            {
                return NotFound("Employees Not Found.");
            }
            return Ok(employees);
        }

        [HttpGet("{id:int}", Name = "GetEmployee")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDTO>> Get(int id)
        {
            if (id < 0)
                return BadRequest("Invalid Id.");

            var employee = await _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound("Employee Not Found.");
            }
            return Ok(employee);
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] EmployeeDTO employeeDto)
        {
            if(employeeDto == null)
                return BadRequest("Invalid Data.");

            employeeDto.Password = Password.EncryptString(_configuration["Keys:encryptKey"], employeeDto.Password);
            await _employeeService.Add(employeeDto);

            return new CreatedAtRouteResult("GetEmployee", new { id = employeeDto.Id }, employeeDto);
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(int id, [FromBody] EmployeeDTO employeeDto)
        {
            if (employeeDto == null)
                return BadRequest("Invalid Data.");

            if (id != employeeDto.Id)
                return BadRequest("The Id from parameters should be equal to the Id from JSON body.");

            var employee = await _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound("Employee Not Found.");
            }

            employeeDto.Password = Password.EncryptString(_configuration["Keys:encryptKey"], employeeDto.Password);
            try
            {
                await _employeeService.Update(employeeDto);
            }
            catch(Exception ex)
            {
                return BadRequest("Error trying to update de employee" + ex.Message);
            }
            return Ok(employeeDto);
        }

        [HttpDelete("{id:int}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeDTO>> Delete(int id)
        {
            if (id < 0)
                return BadRequest("Invalid Id.");

            var employee = await _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound("Employee Not Found.");
            }

            await _employeeService.Remove(id);
            return Ok(employee);
        }
    }
}
