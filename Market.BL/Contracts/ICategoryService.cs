using Market.DAL.Contracts;
using Market.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Contracts
{ 
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategory(int id);
        bool AddCategory(Category category);
        bool UpdateCategory(Category category);

    }
}
