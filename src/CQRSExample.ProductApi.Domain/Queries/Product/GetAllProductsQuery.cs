using System.Linq;
using MediatR;

namespace CQRSExample.ProductApi.Domain.Queries.Product
{
    public class GetAllProductsQuery : IRequest<IQueryable<Model.Product>>
    {
    }
}
