using CadFunc.Application.DTOs;
using CadFunc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadFunc.WebUI.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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

            var employees = await _employeeService.GetEmployees();
            //ViewBag.CategoryId = new SelectList(categories, "Id", "Name", produtoDto.CategoryId);

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
            await _employeeService.Remove(id);
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
