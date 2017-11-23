using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CQRSExample.ProductApi.Domain.Model;

namespace CQRSExample.ProductApi.Infra.Data.Mapping
{
    public class ProductOptionMapping : EntityTypeConfiguration<ProductOption>
    {
        public ProductOptionMapping()
        {
            HasKey(e => e.Id);

            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Name).HasMaxLength(100).IsRequired();
            Property(e => e.Description).HasMaxLength(500).IsRequired();

            HasRequired(e => e.Product);
        }
    }
}
