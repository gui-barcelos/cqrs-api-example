using FluentValidation;
using CQRSExample.ProductApi.Domain.Commands.ProductOption;

namespace CQRSExample.ProductApi.Domain.Validations.Product
{
    public class CreateProductOptionCommandValidation : AbstractValidator<CreateProductOptionCommand>
    {
        public CreateProductOptionCommandValidation()
        {
            RuleFor(e => e.ProductId).NotEmpty().WithMessage("Product Id is required.");
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
