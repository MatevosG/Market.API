using Market.DAL.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Market.DAL.Entities
{
    public class Product : IIdentifiableEntity
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^.*[a-zA-Z]", ErrorMessage = "Please enter a valiv name ")]
        [StringLength(50,ErrorMessage = "the name can't be more than fifty letters ")]
        public string Name { get; set; }
        public double Price { get; set; }
        [Range(1, 50000)]
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
