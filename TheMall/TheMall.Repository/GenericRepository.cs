using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMall.Repository.Mock;

namespace TheMall.Repository
{
    public abstract class GenericRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : class, new() //DbContext //where TContext : DbContext, new()
    {
        //protected TContext DataContext = new TContext(); //todo: remark when implemet the EF
        private readonly IDataContext<TEntity> _dataContext;

        public GenericRepository()
        {
            _dataContext = new MockData<TEntity>();
        }

        public IDataContext<TEntity> Context
        {
            get { return _dataContext; }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            //IQueryable<TEntity> query = DataContext.Set<TEntity>();
            //return query;

            IQueryable<TEntity> query = Context.Entity;//.Cast<TEntity>();
            return query;
        }

        public virtual IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            //IQueryable<T> query = _entities.Set<T>().Where(predicate);
            //return query;

            IQueryable<TEntity> query = GetAll().Where(predicate);
            return query;
        }

        public virtual void Add(TEntity entity)
        {
            //DataContext.Set<TEntity>().Add(entity);

            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            //DataContext.Set<TEntity>().Remove(entity);

            throw new NotImplementedException();
        }

        public virtual void Edit(TEntity entity)
        {
            //DataContext.DataContext(entity).State = System.Data.EntityState.Modified;

            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _dataContext.Entity.AsQueryable();
        }

        public virtual void Save()
        {
            //DataContext.SaveChanges();
        }

        public void Dispose()
        {

        }
    }
}
