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
    public class CustomersController : Controller
    {
        private ICustomerRepository _customRepository;
        private readonly ISaveRepository _saveRepository;
        private IOrderRepository _orderRepository;
        public CustomersController(ICustomerRepository customRepository, ISaveRepository saveRepository, IOrderRepository orderRepository)
        {
            _customRepository = customRepository;
            _saveRepository = saveRepository;
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult GetAllCustomer(string customer_Name)
        {
            if (customer_Name!=null)
            {
                return Ok(_customRepository.GetByNameCustomers(customer_Name));
            }
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
            if (customer == null)
                return NotFound();
            customer.Customer_Name = customerView.Customer_Name;
            customer.Address = customerView.Address;
            customer.Telephone = customerView.Telephone;
            _saveRepository.Save();
            return Ok(customer);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customRepository.GetByIDCustomer(id);
            if (customer == null)
                return NotFound();
            foreach (var item in _orderRepository.GetAllOrder())
            {
                if (customer.Customer_ID == item.Customer_ID)
                    return BadRequest();
            }
            _customRepository.DeleteCustomer(id);
            _saveRepository.Save();
            return Ok(customer);
        }
    }
}
