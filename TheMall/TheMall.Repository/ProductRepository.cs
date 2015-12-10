using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMall.Data;
using TheMall.Model;
using TheMall.Repository.Mock;

namespace TheMall.Repository
{


    public class ProductRepository : GenericRepository<Product, TheMallContext>, IProductRepository //MockData<Product
    {
        private TheMallContext _dbContext;
        private readonly IDbSet<Product> _dbSet;

        public ProductRepository(IDbFactory<TheMallContext> dbFactory)
            : base(dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<Product>();
        }

        protected IDbFactory<TheMallContext> DbFactory
        {
            get;
            private set;
        }

        protected TheMallContext DbContext
        {
            get { return _dbContext ?? (_dbContext = DbFactory.Init()); }
        }

        public Product GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == id);
            return query;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            var query = GetAll().Where(o => o.ProductCategory.Id == categoryId);
            return query;
        }
    }
}
