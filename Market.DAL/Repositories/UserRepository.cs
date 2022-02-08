using Market.DAL.Contracts;
using Market.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Repositories
{
    public class UserRepository : DataRepositoryBase<User>, IUserRepository
    {
        protected override User AddEntity(MarketDbContext entityContext, User entity)
        {
            return entityContext.Users.Add(entity);
        }

        protected override IEnumerable<User> GetEntities(MarketDbContext entityContext)
        {
            return entityContext.Users;
        }

        protected override User GetEntity(MarketDbContext entityContext, int id)
        {
            return entityContext.Users.Find(id);
        }

        protected override User UpdateEntity(MarketDbContext entityContext, User entity)
        {
            return entityContext.Users.FirstOrDefault(x => x.Id == entity.Id);
        }
    }
}
