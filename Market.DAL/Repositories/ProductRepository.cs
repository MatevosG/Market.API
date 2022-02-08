using Market.DAL.Contracts;
using Market.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Market.DAL.Repositories
{
    public class ProductRepository : DataRepositoryBase<Product>, IProductRepository
    {
        protected override Product AddEntity(MarketDbContext entityContext, Product entity)
        {
            return entityContext.Products.Add(entity);
        }

        protected override IEnumerable<Product> GetEntities(MarketDbContext entityContext)
        {
            return entityContext.Products;
        }

        protected override Product GetEntity(MarketDbContext entityContext, int id)
        {
            return entityContext.Products.Find(id);
        }

        protected override Product UpdateEntity(MarketDbContext entityContext, Product entity)
        {
            return entityContext.Products.FirstOrDefault(x=>x.Id==entity.Id);
        }
    }
}
