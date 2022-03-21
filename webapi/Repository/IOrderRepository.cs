using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrder();
        void CreateNewOrder(Order order);
        Order GetByIDOrder(int id);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}
