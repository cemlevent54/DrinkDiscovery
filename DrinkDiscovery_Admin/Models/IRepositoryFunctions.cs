using System.Linq.Expressions;
using System;
using System.Linq;

namespace DrinkDiscovery_Admin.Models
{
    public interface IRepositoryFunctions<T> where T : class
    {
        public IQueryable<T> GetAll();
        public T GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
