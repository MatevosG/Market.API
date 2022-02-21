using Market.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Entities
{
    public class User : IIdentifiableEntity
    {
        public int Id { get ; set ; }
        [Required]
        [RegularExpression(@"^.*[a-zA-Z]", ErrorMessage = "Please enter a valiv name ")]
        [StringLength(50, ErrorMessage = "the name can't be more than fifty letters ")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "the name can't be more than fifty letters ")]
        public string Password { get; set; }
    }
}
