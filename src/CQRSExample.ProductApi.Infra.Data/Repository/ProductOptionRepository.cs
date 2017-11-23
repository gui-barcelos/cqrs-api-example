using CQRSExample.ProductApi.Domain.Model;
using CQRSExample.ProductApi.Domain.Repository.Interfaces;
using CQRSExample.ProductApi.Infra.Data.Context;
using CQRSExample.ProductApi.Infra.Data.Repository.BaseRepositories;

namespace CQRSExample.ProductApi.Infra.Data.Repository
{
    public class ProductOptionRepository : Repository<ProductOption>, IProductOptionRepository
    {
        public ProductOptionRepository(ProductsContext context) : base(context)
        { }
    }
}
