using MediatR;
using System;

namespace CQRSExample.ProductApi.Domain.Commands.ProductOption
{
    public class DeleteProductOptionCommand : IRequest
    {
        public DeleteProductOptionCommand(Guid id)
        { 
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
