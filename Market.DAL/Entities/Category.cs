using Market.DAL.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Market.DAL.Entities
{
    public class Category : IIdentifiableEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
