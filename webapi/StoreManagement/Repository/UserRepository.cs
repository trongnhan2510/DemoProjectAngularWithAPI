using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private StoreManagementDbContext _context;
        public UserRepository(StoreManagementDbContext context)
        {
            _context = context;
        }
        public void CreateNewUser(User user)
        {
            _context.Users.Add(user);
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
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

        public User getByIDUser(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }
        public User getByUsername(string username)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == username);
            return user;
        }

        public IEnumerable<User> getUserAll()
        {
            var listUser = _context.Users.AsEnumerable();
            return listUser;
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public User GetUser(string userName, string passWord)
        {
            return _context.Users.FirstOrDefault(u => u.Username == userName && u.Password == passWord);
        }
    }
}
