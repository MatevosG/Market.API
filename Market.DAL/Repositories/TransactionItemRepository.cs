using Market.DAL.Contracts;
using Market.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Repositories
{
    public class TransactionItemRepository : DataRepositoryBase<TransactionItem>, ITransactionItemRepository
    {
        protected override TransactionItem AddEntity(MarketDbContext entityContext, TransactionItem entity)
        {
            return entityContext.TransactionItems.Add(entity);
        }

        protected override IEnumerable<TransactionItem> GetEntities(MarketDbContext entityContext)
        {
            return entityContext.TransactionItems;
        }

        protected override TransactionItem GetEntity(MarketDbContext entityContext, int id)
        {
            return entityContext.TransactionItems.FirstOrDefault(x=>x.Id==id);
        }

        protected override TransactionItem UpdateEntity(MarketDbContext entityContext, TransactionItem entity)
        {
            return entityContext.TransactionItems.FirstOrDefault(x=>x.Id==entity.Id);
        }
    }
}
