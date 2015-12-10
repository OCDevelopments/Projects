using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMall.Data;
using TheMall.Model;
using TheMall.Repository.Mock;

namespace TheMall.Repository
{
    public class CategoryRepository : GenericRepository<Category, TheMallContext>, ICategoryRepository //MockData<Product>
    {
        public CategoryRepository(IDbFactory<TheMallContext> dbFactory)
            : base(dbFactory) { }
    }
}
