using Market.DAL.Contracts;
using Market.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Repositories
{
    public class TokenRepository : DataRepositoryBase<Token>, ITokenRepository
    {
        protected override Token AddEntity(MarketDbContext entityContext, Token entity)
        {
            return entityContext.Tokens.Add(entity);
        }

        protected override IEnumerable<Token> GetEntities(MarketDbContext entityContext)
        {
            return entityContext.Tokens;
        }

        protected override Token GetEntity(MarketDbContext entityContext, int id)
        {
            return entityContext.Tokens.Find(id);
        }

        protected override Token UpdateEntity(MarketDbContext entityContext, Token entity)
        {
            return entityContext.Tokens.FirstOrDefault(x=>x.Id==entity.Id);
        }
    }
}
