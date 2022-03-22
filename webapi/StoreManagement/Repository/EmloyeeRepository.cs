using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Repository
{
    public class EmloyeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly StoreManagementDbContext _context;
        public EmloyeeRepository(StoreManagementDbContext context)
        {
            _context = context;
        }
        public void CreateNewEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees.AsEnumerable();
        }

        public Employee GetByIDEmployee(int id)
        {
            return _context.Employees.Find(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
    }
}
