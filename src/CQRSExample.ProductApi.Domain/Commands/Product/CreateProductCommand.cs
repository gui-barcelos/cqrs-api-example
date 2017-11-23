using MediatR;

namespace CQRSExample.ProductApi.Domain.Commands.Product
{
    public class CreateProductCommand : MediatR.IRequest
    {
        public CreateProductCommand(string name, string description, decimal price, decimal deliveryPrice)
        {
            Name = name;
            Description = description;
            Price = price;
            DeliveryPrice = deliveryPrice;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
