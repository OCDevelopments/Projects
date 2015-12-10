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
    public class StoreRepository : GenericRepository<Store, TheMallContext>, IStoreRepository //MockData<Store>
    {
        public StoreRepository(IDbFactory<TheMallContext> dbFactory)
            : base(dbFactory) { }
    }
}
