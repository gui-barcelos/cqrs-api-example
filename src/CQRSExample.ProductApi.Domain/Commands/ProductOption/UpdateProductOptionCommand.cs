using MediatR;
using System;

namespace CQRSExample.ProductApi.Domain.Commands.ProductOption
{
    public class UpdateProductOptionCommand : IRequest
    {
        public UpdateProductOptionCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
