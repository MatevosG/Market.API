using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Contracts
{
    public interface IDataRepository
    {

    }
    public interface IRepository<T> : IDataRepository
        where T: class, IIdentifiableEntity,new()
    {
        IEnumerable<T> Get();
        T Get(int id);
        T Add(T obj);
        T Update(T obj);
        void Remove(int id);
        void Remove(T obj);
    }
}
