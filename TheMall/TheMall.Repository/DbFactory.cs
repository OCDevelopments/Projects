using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMall.Data;

namespace TheMall.Repository
{
    public class DbFactory : IDbFactory<TheMallContext>
    {
        TheMallContext _dbContext;

        public void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }

        TheMallContext IDbFactory<TheMallContext>.Init()
        {
            return _dbContext ?? (_dbContext = new TheMallContext());
        }
    }
}
