using System;
using System.Linq;
using MediatR;

namespace CQRSExample.ProductApi.Domain.Queries.ProductOption
{
    public class GetProductOptionQuery : IRequest<Model.ProductOption>
    {
        public GetProductOptionQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
