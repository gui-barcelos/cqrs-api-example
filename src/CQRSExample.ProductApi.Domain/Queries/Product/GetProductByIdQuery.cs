using System;
using MediatR;

namespace CQRSExample.ProductApi.Domain.Queries.Product
{
    public class GetProductByIdQuery : IRequest<Model.Product>
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
