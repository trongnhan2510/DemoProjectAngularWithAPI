using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StoreManagement.Repository
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private readonly StoreManagementDbContext _context;
        public CustomerRepository(StoreManagementDbContext context)
        {
            _context = context;
        }
        public void CreateNewCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
        }
        public IEnumerable<Customer> GetAllCustomer()
        {
            string listCustomerToCallStored = "EXEC sp_GetAllCustomer";
            return _context.Customers.FromSqlRaw(listCustomerToCallStored);
        }
        public Customer GetByIDCustomer(int id)
        {
            return _context.Customers.Find(id);
        }
        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Customer> GetByNameCustomers(string nameCus)
        {
            return _context.Customers.Where(x => x.Customer_Name.Contains(nameCus));
        }
    }
}
