using MediatR;
using System;

namespace CQRSExample.ProductApi.Domain.Commands.Product
{
    public class UpdateProductCommand : MediatR.IRequest
    {
        public UpdateProductCommand(Guid id, string name, string description, decimal price, decimal deliveryPrice)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            DeliveryPrice = deliveryPrice;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
