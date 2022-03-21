using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Models
{
    public class Employee
    {
        public int Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public Boolean Gender { get; set; }
        public string Address { get; set; }
        public string TelePhone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
