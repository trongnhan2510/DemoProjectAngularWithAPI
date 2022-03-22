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
        private readonly IOrderRepository _orderRepository;
        public EmployeesController(IEmployeeRepository employeeRepository, ISaveRepository saveRepository, IOrderRepository orderRepository)
        {
            _employeeRepository = employeeRepository;
            _saveRepository = saveRepository;
            _orderRepository = orderRepository;
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
            if (employee == null)
                return NotFound();
            foreach (var item in _orderRepository.GetAllOrder())
            {
                if (employee.Employee_ID == item.Employee_ID)
                    return BadRequest();
            }
            _employeeRepository.DeleteEmployee(id);
            _saveRepository.Save();
            return Ok(employee);

        }
    }
}
