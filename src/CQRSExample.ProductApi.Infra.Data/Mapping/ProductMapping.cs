using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CQRSExample.ProductApi.Domain.Model;

namespace CQRSExample.ProductApi.Infra.Data.Mapping
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            HasKey(e => e.Id);

            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Name).HasMaxLength(100).IsRequired();
            Property(e => e.Description).HasMaxLength(500).IsRequired();
            Property(e => e.Price).HasPrecision(18,2).IsRequired();
            Property(e => e.DeliveryPrice).HasPrecision(18, 2).IsRequired();

            HasMany(e => e.Options)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete();
        }
    }
}
