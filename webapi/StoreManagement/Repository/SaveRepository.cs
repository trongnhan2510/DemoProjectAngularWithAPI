using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Repository
{
    public class SaveRepository : ISaveRepository
    {
        private readonly StoreManagementDbContext _context;
        public SaveRepository(StoreManagementDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
            
        }
    }
}
