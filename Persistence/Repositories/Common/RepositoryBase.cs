using Domain.Repositories;
using Domain.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public abstract class RepositoryBase<T>(DataContext dataContext) : IRepositoryBase<T> where T : class
    {
        public IQueryable<T> FindAll() => dataContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => dataContext.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => dataContext.Set<T>().Add(entity);

        public void Update(T entity) => dataContext.Set<T>().Update(entity);

        public void Delete(T entity) => dataContext.Set<T>().Remove(entity);
    }
}