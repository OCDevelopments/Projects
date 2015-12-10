using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMall.Data;

namespace TheMall.Repository
{
    //https://lostechies.com/derekgreer/2015/11/01/survey-of-entity-framework-unit-of-work-patterns/

    //SHOULD IMPLEMENT UoW with good abstraction, look:
    //http://blog.longle.net/2013/05/11/genericizing-the-unit-of-work-pattern-repository-pattern-with-entity-framework-in-mvc/

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbFactory<TheMallContext> _dbFactory;
        private TheMallContext _dbContext;

        private Dictionary<string, dynamic> _repositories;


        public UnitOfWork(IDbFactory<TheMallContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public TheMallContext DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }

        public void Rollback()
        {
            //DbContext.
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }


        //        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        //        {
        //            if (_repositories == null)
        //                _repositories = new Dictionary<string, dynamic>();
        //
        //
        //            var type = typeof(TEntity).Name;
        //
        //            if (!_repositories.ContainsKey(type))
        //            {
        //                var repositoryType = typeof(GenericRepository<,>);
        //
        //                var repositoryInstance =
        //                    Activator.CreateInstance(repositoryType
        //                            .MakeGenericType(typeof(TEntity),typeof(TheMallContext)), _dbContext);
        //
        //                _repositories.Add(type, repositoryInstance);
        //            }
        //
        //            return (IRepository<TEntity>)_repositories[type];
        //        }

    }
}
