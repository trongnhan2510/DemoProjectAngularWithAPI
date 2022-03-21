    using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.Models;
using StoreManagement.Repository;
using StoreManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISaveRepository _saveRepository;
        public EmployeesController(IEmployeeRepository employeeRepository, ISaveRepository saveRepository)
        {
            _employeeRepository = employeeRepository;
            _saveRepository = saveRepository;
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var listEmployee = _employeeRepository.GetAllEmployee();
            return Ok(listEmployee);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIDEmployee(int id)
        {
            var employee = _employeeRepository.GetByIDEmployee(id);
            if (employee==null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult CreateNewEmployee(EmployeeView employeeView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var employee = new Employee
                {
                    Employee_Name = employeeView.Employee_Name,
                    Address = employeeView.Address,
                    Gender = employeeView.Gender,
                    DateOfBirth = employeeView.DateOfBirth,
                    TelePhone = employeeView.TelePhone
                };
                _employeeRepository.CreateNewEmployee(employee);
                _saveRepository.Save();
                return Ok(employee);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeView employeeView)
        {
                var employee = _employeeRepository.GetByIDEmployee(id);
                if (employee == null)
                    return NotFound();
                employee.Employee_Name = employeeView.Employee_Name;
                employee.Address = employeeView.Address;
                employee.Gender = employeeView.Gender;
                employee.DateOfBirth = employeeView.DateOfBirth;
                employee.TelePhone = employeeView.TelePhone;
                _saveRepository.Save();
                return Ok(employee);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetByIDEmployee(id);
            if (employee != null)
            {
                _employeeRepository.DeleteEmployee(id);
                _saveRepository.Save();
                return Ok(employee);
            }
            else
                return NotFound();
        }
    }
}
