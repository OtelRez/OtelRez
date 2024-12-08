using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.DAL.Repositories.Abstract
{
    public interface IRepository<T> where T : BaseEntity, IEntity
    {
        public Task<int> CreateAsync(T entity);
        public Task<int> UpdateAsync(T entity);
        public Task<int> DeleteAsync(T entity);

        public Task<T?> GetByIdAsync(string id);
        public Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        public Task<List<T>?> GetAllAsync(Expression<Func<T, bool>> predicate = null);

        public Task<IQueryable<T>?> GetAllIncludeAsync(Expression<Func<T, bool>> predicate = null
            , params Expression<Func<T, object>>[] include);

    }
}
