using MediatR;
using System;

namespace CQRSExample.ProductApi.Domain.Commands.Product
{
    public class DeleteProductCommand : MediatR.IRequest
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
