using Market.BL.Contracts;
using Market.DAL.Contracts;
using Market.DAL.Entities;
using Market.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Sevices
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(User user)
        {
            bool res = false;

            if (!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Password))
            {
                _userRepository.Add(user);
                    res = true;
            }
                return res;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            OparationUserModel oparation = new OparationUserModel();
            var users = _userRepository.Get();
            if (users!=null)
            {
                foreach (var user in users)
                {
                    UserModel userModel = new UserModel();
                    userModel.Id = user.Id;
                    userModel.name = user.Name;
                    oparation.UserModels.Add(userModel);
                }
            }
            return oparation.UserModels;
        }

        public UserModel GetUserById(int id)
        {
           var user = _userRepository.Get(id);
            if (user!= null)
            {
                UserModel userModel = new UserModel();
                userModel.name = user.Name;
                userModel.Id = user.Id;
                return userModel;
            }
                return null;
        }

        public bool UpdateUser(User user)
        {
            bool res = false;
             var isUser = _userRepository.Update(user);
                if (isUser != null)
                {
                   res = true;
                }
                return res;
        }
    }
}
