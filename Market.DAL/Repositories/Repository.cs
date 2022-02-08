using Market.DAL.Contracts;
using Market.DAL.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Repositories
{
    public abstract class Repository<T, U> : IRepository<T>
         where T : class, IIdentifiableEntity, new()
        where U: DbContext,new()
    {
        protected abstract T AddEntity(U entityContext, T entity);

        protected abstract T UpdateEntity(U entityContext, T entity);

        protected abstract IEnumerable<T> GetEntities(U entityContext);

        protected abstract T GetEntity(U entityContext, int id);
        public T Add(T entity)
        {
            using (U entityContext = new U())
            {
                T addedEntity = AddEntity(entityContext, entity);
                entityContext.SaveChanges();
                return addedEntity;
            }
        }

        public IEnumerable<T> Get()
        {
            using (U entityContext = new U())
                return (GetEntities(entityContext)).ToArray().ToList();
        }

        public T Get(int id)
        {
            using (U entityContext = new U())
                return GetEntity(entityContext, id);
        }

        public void Remove(int id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            using (U entityContext = new U())
            {
                T existingEntity = UpdateEntity(entityContext, entity);

                SimpleMapper.PropertyMap(entity, existingEntity);
               
                entityContext.SaveChanges();
                return entity;
            }
        }

        public void Remove(T obj)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry<T>(obj).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }
    }
}
