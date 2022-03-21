using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Models
{
    public class Order
    {
        [Key]
        public int Order_ID { get; set; }
        public int Employee_ID { get; set; }
        public int Customer_ID { get; set; }
        public DateTime SaleofDate { get; set; }
        public double Total { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
    }
}
