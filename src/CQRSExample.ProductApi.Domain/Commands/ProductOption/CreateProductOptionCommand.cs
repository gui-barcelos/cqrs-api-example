using MediatR;
using System;

namespace CQRSExample.ProductApi.Domain.Commands.ProductOption
{
    public class CreateProductOptionCommand : IRequest
    {
        public CreateProductOptionCommand(Guid productId, string name, string description)
        {
            ProductId = productId;
            Name = name;
            Description = description;
        }

        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
