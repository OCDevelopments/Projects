using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMall.Model;
using TheMall.Repository.Mock;

namespace TheMall.Repository
{
    public class ProductRepository : GenericRepository<Product, MockData<Product>>, IProductRepository
    {
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
