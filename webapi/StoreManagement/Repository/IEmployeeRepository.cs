using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        void CreateNewEmployee(Employee employee);
        Employee GetByIDEmployee(int id);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
