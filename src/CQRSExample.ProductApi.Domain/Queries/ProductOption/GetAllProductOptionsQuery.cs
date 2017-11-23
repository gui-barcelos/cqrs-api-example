using System;
using System.Linq;
using MediatR;

namespace CQRSExample.ProductApi.Domain.Queries.ProductOption
{
    public class GetAllProductOptionsQuery : IRequest<IQueryable<Model.ProductOption>>
    {
        public GetAllProductOptionsQuery(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }
}
