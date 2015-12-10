using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMall.Data;
using TheMall.Repository.Mock;

namespace TheMall.Repository
{
    public abstract class GenericRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
    //where TContext : class, new() //when working with mock
    {
        //protected readonly TContext DataContext;// = new TContext(); //todo: remark when implemet the EF
        //private readonly IDataContext<TEntity> _dataContext;

        private TContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;

        public GenericRepository(IDbFactory<TContext> dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<TEntity>();
        }

        protected IDbFactory<TContext> DbFactory
        {
            get;
            private set;
        }

        protected TContext DbContext
        {
            get { return _dbContext ?? (_dbContext = DbFactory.Init()); }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;
            return query;

            //            IQueryable<TEntity> query = Context.Entity;//.Cast<TEntity>();
            //            return query;
        }

        public virtual IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _dbSet.Where(predicate);
            return query;

            //            IQueryable<TEntity> query = GetAll().Where(predicate);
            //            return query;
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        //        public virtual IQueryable<TEntity> AsQueryable()
        //        {
        //            return _dataContext.Entity.AsQueryable();
        //        }


        public void Dispose()
        {

        }
    }
}
