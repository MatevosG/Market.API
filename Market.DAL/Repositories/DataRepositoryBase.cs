using Market.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Repositories
{
    public abstract class DataRepositoryBase<T> : Repository<T, MarketDbContext>
         where T : class, IIdentifiableEntity, new()
    {

    }
}
