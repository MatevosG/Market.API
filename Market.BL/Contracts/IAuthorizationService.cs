using Market.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Contracts
{
    public interface IAuthorizationService
    {
        string CreateToken(User user);
        User TryGetUser(User user);
    }
}
