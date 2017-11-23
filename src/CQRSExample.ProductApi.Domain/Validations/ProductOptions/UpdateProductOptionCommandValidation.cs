using FluentValidation;
using CQRSExample.ProductApi.Domain.Commands.ProductOption;

namespace CQRSExample.ProductApi.Domain.Validations.Product
{
    public class UpdateProductOptionCommandValidation : AbstractValidator<UpdateProductOptionCommand>
    {
        public UpdateProductOptionCommandValidation()
        {
            RuleFor(e => e.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
