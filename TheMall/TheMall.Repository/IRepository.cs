using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TheMall.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        void Save();

        //=================================
        IQueryable<TEntity> AsQueryable();
//        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
//        TEntity Single(Expression<Func<TEntity, bool>> predicate);
//        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
//        TEntity First(Expression<Func<TEntity, bool>> predicate);
//        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
//        TEntity GetById(int id);
//        void Attach(TEntity entity);
    }
}
