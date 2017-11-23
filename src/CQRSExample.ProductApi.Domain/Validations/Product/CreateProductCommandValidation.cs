using FluentValidation;
using CQRSExample.ProductApi.Domain.Commands.Product;

namespace CQRSExample.ProductApi.Domain.Validations.Product
{
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidation()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(e => e.Price).NotEmpty().WithMessage("Price is required.");
            RuleFor(e => e.DeliveryPrice).NotEmpty().WithMessage("Delivery Price is required.");
        }
    }
}
