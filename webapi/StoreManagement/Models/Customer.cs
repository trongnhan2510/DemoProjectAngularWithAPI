using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Models
{
    public class Customer
    {
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
