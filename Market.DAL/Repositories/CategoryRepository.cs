using Market.DAL.Contracts;
using Market.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Repositories
{
    public class CategoryRepository : DataRepositoryBase<Category>, ICategoryRepository
    {
        protected override Category AddEntity(MarketDbContext entityContext, Category entity)
        {
            return entityContext.Categories.Add(entity);
        }

        protected override IEnumerable<Category> GetEntities(MarketDbContext entityContext)
        {
            var category = entityContext.Categories;
            return category;
        }

        protected override Category GetEntity(MarketDbContext entityContext, int id)
        {
            return entityContext.Categories.FirstOrDefault(x => x.Id == id);
        }

        protected override Category UpdateEntity(MarketDbContext entityContext, Category entity)
        {
             return entityContext.Categories.FirstOrDefault(x => x.Id == entity.Id);
        }
    }
}
