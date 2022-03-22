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
        public object CreateNewCustomer(Customer customer)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter("@customer_Name",customer.Customer_Name),
                new SqlParameter("@address",customer.Address),
                new SqlParameter("@telephone",customer.Telephone),
            };
            //_context.Database.ExecuteSqlRaw("EXEC sp_CreateNewCustomer @p0, @p1, @p2",parameters: new[] { customer.Customer_Name,customer.Address,customer.Telephone});
            return _context.Database.ExecuteSqlRaw("EXEC sp_CreateNewCustomer @customer_Name, @address, @telephone", param);
        }

        public void DeleteCustomer(int id)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_DeleteCustomer @p0",id);
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
            //
            var param = new SqlParameter[]
            {
                new SqlParameter("@customer_ID",customer.Customer_ID),
                new SqlParameter("@customer_Name",customer.Customer_Name),
                new SqlParameter("@address",customer.Address),
                new SqlParameter("@telephone",customer.Telephone),
            };
            _context.Database.ExecuteSqlRaw("EXEC sp_UpdateCustomer @customer_ID,@customer_Name, @address, @telephone", param);
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
