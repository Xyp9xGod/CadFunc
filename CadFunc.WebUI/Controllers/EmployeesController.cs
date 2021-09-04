using CadFunc.Application.DTOs;
using CadFunc.Application.Interfaces;
using CadFunc.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CadFunc.WebUI.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IConfiguration _configuration;
        public EmployeesController(IEmployeeService employeeService, IConfiguration configuration)
        {
            _employeeService = employeeService;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDTO employeeDto)
        {
            if (ModelState.IsValid)
            {
                //employeeDto.Password = Password.EncryptString(_configuration["Keys:encryptKey"], employeeDto.Password);
                await _employeeService.Add(employeeDto);
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDto);
        }
        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var employeeDto = await _employeeService.GetById(id);

            if (employeeDto == null) return NotFound();
            //employeeDto.Password = Password.DecryptString(_configuration["Keys:encryptKey"], employeeDto.Password);

            return View(employeeDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeDTO employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeService.Update(employeeDto);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDto);
        }
        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var employeeDto = await _employeeService.GetById(id);
            if (employeeDto == null) return NotFound();

            return View(employeeDto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            try
            {
                await _employeeService.Remove(id);
            }
            catch(Exception ex)
            {
                return BadRequest("Problems to delete de employee. "+ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet()]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var employeeDto = await _employeeService.GetById(id);
            if (employeeDto == null) return NotFound();

            return View(employeeDto);
        }
    }
}
