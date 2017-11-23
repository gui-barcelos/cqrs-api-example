using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CQRSExample.ProductApi.Infra.Data.Context;

namespace CQRSExample.ProductApi.Infra.Data.Repository.BaseRepositories
{
    public class Repository<T> where T : class
    {
        protected readonly ProductsContext Context;
        protected readonly DbSet<T> DbSet;

        public Repository(ProductsContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual T GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).AsNoTracking();
        }
    }
}
