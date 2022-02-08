using Market.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Entities
{
    public class TransactionItem : IIdentifiableEntity
    {
        public int Id { get; set ; }
        public int ProductId { get; set ; }
        public virtual Product Product { get; set ; }
        public int ProductCount { get; set; }
        public int TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }
        public double Price { get; set; }
       
    }
}
