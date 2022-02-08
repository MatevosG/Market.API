using Market.DAL.Entities;
using Market.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        bool AddUser(User user);
        bool UpdateUser(User user);
    }
}
