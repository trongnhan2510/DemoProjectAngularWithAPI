using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> getUserAll();
        User getByIDUser(int id);
        void CreateNewUser(User user);
        void UpdateUser(User user);
        void Delete(int id);
        User GetUser(string userName, string passWord);
        User getByUsername(string username);
    }
}
