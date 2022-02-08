using Market.DAL.Contracts;
using Market.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Repositories
{
    public class TransactionRepository : DataRepositoryBase<Transaction>, ITransactinRepository
    {
        protected override Transaction AddEntity(MarketDbContext entityContext, Transaction entity)
        {
            return entityContext.Transactions.Add(entity);
        }

        protected override IEnumerable<Transaction> GetEntities(MarketDbContext entityContext)
        {
            return from e in entityContext.Transactions
                   select e;
        }

        protected override Transaction GetEntity(MarketDbContext entityContext, int id)
        {
            var query = (from e in entityContext.Transactions
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        protected override Transaction UpdateEntity(MarketDbContext entityContext, Transaction entity)
        {
            return (from e in entityContext.Transactions
                    where e.Id == entity.Id
                    select e).FirstOrDefault();
        }
    }
}
