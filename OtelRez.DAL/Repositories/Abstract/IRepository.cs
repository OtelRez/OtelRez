using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.DAL.Repositories.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        public int Create(T entity);
        public int Update(T entity);
        public int Delete(T entity);

        public T? GetById(int id);
        public T? Get(Expression<Func<T, bool>> predicate);
        public List<T>? GetAll(Expression<Func<T, bool>> predicate = null);

        public IQueryable<T>? GetAllInclude(Expression<Func<T, bool>> predicate = null
            , params Expression<Func<T, object>>[] include);
        

    }
}
