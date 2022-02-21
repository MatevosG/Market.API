using Market.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Entities
{
    public class Token : IIdentifiableEntity
    {
        public int Id { get ; set ; }
        public string Tokens { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ExpirationTime { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
