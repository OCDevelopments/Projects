using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMall.Model;

namespace TheMall.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetById(int id);
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
    }
}
