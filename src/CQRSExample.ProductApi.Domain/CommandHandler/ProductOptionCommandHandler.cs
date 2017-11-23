using MediatR;
using CQRSExample.ProductApi.Domain.Commands.ProductOption;
using CQRSExample.ProductApi.Domain.Interfaces.UnitOfWork;
using CQRSExample.ProductApi.Domain.Repository.Interfaces;

namespace CQRSExample.ProductApi.Domain.CommandHandler
{
    public class ProductOptionCommandHandler : CommandHandler,
                                                IRequestHandler<CreateProductOptionCommand>,
                                                IRequestHandler<UpdateProductOptionCommand>,
                                                IRequestHandler<DeleteProductOptionCommand>
    {
        private IProductOptionRepository _productOptionRepository;
        public ProductOptionCommandHandler(IUnitOfWork uow, IProductOptionRepository productRepository) : base(uow)
        {
            _productOptionRepository = productRepository;
        }

        public void Handle(DeleteProductOptionCommand command)
        {
            _productOptionRepository.Remove(command.Id);

            Commit();
        }

        public void Handle(CreateProductOptionCommand command)
        {
            _productOptionRepository.Add(new Model.ProductOption()
            {
                Name = command.Name,
                Description = command.Description
            });

            Commit();
        }

        public void Handle(UpdateProductOptionCommand command)
        {
            var product = _productOptionRepository.GetById(command.Id);

            product.Name = command.Name;
            product.Description = command.Description;

            Commit();
        }
    }
}
