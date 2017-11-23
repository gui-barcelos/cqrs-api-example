using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CQRSExample.ProductApi.Domain.Model;

namespace CQRSExample.ProductApi.Infra.Data.Context
{
    public class ProductsContext : DbContext
    {
        public ProductsContext() : base("ProductsDbConnectionString")
        {
            Database.SetInitializer(new ProductsContextInitializer());
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductOption> ProductOption { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(typeof(ProductsContext).Assembly);
        }
    }
}
