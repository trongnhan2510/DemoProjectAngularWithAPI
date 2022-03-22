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
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISaveRepository _saveRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomerRepository _customerRepository;
        public OrdersController(IOrderRepository orderRepository, ISaveRepository saveRepository, IEmployeeRepository employeeRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _saveRepository = saveRepository;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public IActionResult getOrderAll()
        {
            var listOrders = _orderRepository.GetAllOrder();
            return Ok(listOrders);
        }
        [HttpGet("{id}")]
        public IActionResult getByIDOrder(int id)
        {
            var order = _orderRepository.GetByIDOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost]
        public IActionResult CreateNewOrder( OrderView orderView)
        {
            try
            {
                var employee = _employeeRepository.GetByIDEmployee(orderView.Employee_ID);
                if (employee == null)
                    return NotFound();
                var customer = _customerRepository.GetByIDCustomer(orderView.Customer_ID);
                if (customer == null)
                    return NotFound();
                var order = new Order
                {
                    SaleofDate = orderView.SaleofDate,
                    Total = orderView.Total,
                    Customer_ID = orderView.Customer_ID,
                    Employee_ID = orderView.Employee_ID,
                };
                _orderRepository.CreateNewOrder(order);
                _saveRepository.Save();
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, OrderView orderView)
        {
            var order = _orderRepository.GetByIDOrder(id);
            if (order == null)
                return NotFound();
            order.SaleofDate = orderView.SaleofDate;
            order.Total = orderView.Total;
            order.Customer_ID = orderView.Customer_ID;
            order.Employee_ID = orderView.Employee_ID;
            _saveRepository.Save();
            return Ok(order);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _orderRepository.GetByIDOrder(id);
            if (order == null)
                return NotFound();
            _orderRepository.DeleteOrder(id);
            _saveRepository.Save();
            return Ok(order);
        }
    }
}
