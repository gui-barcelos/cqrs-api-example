using CQRSExample.ProductApi.Domain.Interfaces.Repository;
using CQRSExample.ProductApi.Domain.Model;

namespace CQRSExample.ProductApi.Domain.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
