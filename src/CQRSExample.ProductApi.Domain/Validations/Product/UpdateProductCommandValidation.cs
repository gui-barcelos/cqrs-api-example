using FluentValidation;
using CQRSExample.ProductApi.Domain.Commands.Product;
using CQRSExample.ProductApi.Domain.Repository.Interfaces;

namespace CQRSExample.ProductApi.Domain.Validations.Product
{
    public class UpdateProductCommandValidation : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            RuleFor(e => e.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(e => e.Price).NotEmpty().WithMessage("Price is required.");
            RuleFor(e => e.DeliveryPrice).NotEmpty().WithMessage("Delivery Price is required.");
        }
    }
}
