using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Models
{
    public class OparationUserModel
    {
        public OparationUserModel()
        {
            UserModels = new List<UserModel>();
        }
        public List<UserModel> UserModels { get; set; }
    }

    public  class UserModel
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
}
