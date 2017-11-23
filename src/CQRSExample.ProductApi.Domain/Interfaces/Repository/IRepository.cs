using System;
using System.Linq;
using System.Linq.Expressions;

namespace CQRSExample.ProductApi.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        T GetById(Guid id);

        IQueryable<T> GetAll();

        void Update(T entity);

        void Remove(Guid id);

        IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate);
    }
}
