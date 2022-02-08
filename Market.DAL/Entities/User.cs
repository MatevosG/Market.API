using Market.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Entities
{
    public class User : IIdentifiableEntity
    {
        public int Id { get ; set ; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
