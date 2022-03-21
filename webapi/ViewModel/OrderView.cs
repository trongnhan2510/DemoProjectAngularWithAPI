using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModel
{
    public class OrderView
    {
        public int Employee_ID { get; set; }
        public int Customer_ID { get; set; }
        public DateTime SaleofDate { get; set; }
        public double Total { get; set; }
    }
}
