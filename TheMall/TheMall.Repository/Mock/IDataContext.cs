using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TheMall.Model;

namespace TheMall.Repository.Mock
{
    public interface IDataContext<TEntity> where TEntity : class
    {
        IEnumerable<Product> Product { get; }
        IEnumerable<Store> Store { get; }
        IEnumerable<Category> Category { get; }
        IQueryable<TEntity> Entity { get; }
    }
}
