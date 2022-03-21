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
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private ICustomerRepository _customRepository;
        private readonly ISaveRepository _saveRepository;
        public CustomersController(ICustomerRepository customRepository, ISaveRepository saveRepository)
        {
            _customRepository = customRepository;
            _saveRepository = saveRepository;
        }
        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            var listCustomer = _customRepository.GetAllCustomer();
            return Ok(listCustomer);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIDCustomer(int id)
        {
            var customer = _customRepository.GetByIDCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpGet("GetByName/{name}")]
        public IActionResult GetByNameCustomer(string name)
        {
            var customer = _customRepository.GetByNameCustomers(name);
            if (customer == null && name == null)
            {
                return Ok(GetAllCustomer());
            }
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult CreateNewCustomer(CustomerView customerView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var customer = new Customer
                {
                    Customer_Name = customerView.Customer_Name,
                    Address = customerView.Address,
                    Telephone = customerView.Telephone
                };
                _customRepository.CreateNewCustomer(customer);
                _saveRepository.Save();
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id,CustomerView customerView)
        {
            var customer = _customRepository.GetByIDCustomer(id);
            if (customer != null)
            {
                customer.Customer_Name = customerView.Customer_Name;
                customer.Address = customerView.Address;
                customer.Telephone = customerView.Telephone;
                _saveRepository.Save();
                return Ok(customer);
            }
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customRepository.GetByIDCustomer(id);
            if (customer != null)
            {
                _customRepository.DeleteCustomer(id);
                _saveRepository.Save();
                return Ok(customer);
            }
            else
                return NotFound();
        }
    }
}
