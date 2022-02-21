using Market.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Entities
{
    public class Transaction : IIdentifiableEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public virtual ICollection<TransactionItem> TransactionItems { get; set; }
    }
}
