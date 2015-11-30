using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMall.Model;
using TheMall.Repository.Mock;

namespace TheMall.Repository
{
    public class CategoryRepository : GenericRepository<Category, MockData<Product>>, ICategoryRepository
    {
    }
}
