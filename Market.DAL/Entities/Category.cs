using Market.DAL.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Market.DAL.Entities
{
    public class Category : IIdentifiableEntity
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^.*[a-zA-Z]", ErrorMessage = "Please enter a valiv name ")]
        [StringLength(50, ErrorMessage = "the name can't be more than fifty letters ")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
