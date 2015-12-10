using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMall.Model;

namespace TheMall.Data
{
    //http://bitoftech.net/2013/11/25/building-database-model-entityframework-code-first/
    //http://chsakell.com/2015/02/15/asp-net-mvc-solution-architecture-best-practices/
    //http://blog.longle.net/2013/05/11/genericizing-the-unit-of-work-pattern-repository-pattern-with-entity-framework-in-mvc/ //IMPORTANT!!! try to implement this

    public class TheMallContext : DbContext
    {
        static TheMallContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TheMallContext, TheMallContextMigrationConfiguration>());
        }

        public TheMallContext()
            : base("Name=TheMallContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public virtual void Rollback()
        {
            //base.();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMapper());
            modelBuilder.Configurations.Add(new StoreMapper());
            modelBuilder.Configurations.Add(new CategoryMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}
