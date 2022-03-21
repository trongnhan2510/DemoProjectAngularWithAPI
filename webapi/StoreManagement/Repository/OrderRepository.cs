using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Repository
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private readonly StoreManagementDbContext _context;
        public OrderRepository(StoreManagementDbContext context)
        {
            _context = context;
        }
        public void CreateNewOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void DeleteOrder(int id)
        {
            Order order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
        }
        public IEnumerable<Order> GetAllOrder()
        {
            return _context.Orders.ToList();
        }

        public Order GetByIDOrder(int id)
        {
            return _context.Orders.Find(id);
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
