using Market.DAL.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Market.DAL.Entities
{
    public class Product : IIdentifiableEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
