using MediatR;
using CQRSExample.ProductApi.Domain.Commands.Product;
using CQRSExample.ProductApi.Domain.Interfaces.UnitOfWork;
using CQRSExample.ProductApi.Domain.Repository.Interfaces;

namespace CQRSExample.ProductApi.Domain.CommandHandler
{
    public class ProductCommandHandler : CommandHandler, 
                                                IRequestHandler<CreateProductCommand>, 
                                                IRequestHandler<UpdateProductCommand>, 
                                                IRequestHandler<DeleteProductCommand>
    {
        private IProductRepository _productRepository;
        public ProductCommandHandler(IUnitOfWork uow, IProductRepository productRepository) : base(uow)
        {
            _productRepository = productRepository;
        }

        public void Handle(DeleteProductCommand command)
        {
            _productRepository.Remove(command.Id);

            Commit();
        }

        public void Handle(CreateProductCommand command)
        {
            _productRepository.Add(new Model.Product()
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
                DeliveryPrice = command.DeliveryPrice
            });

            Commit();
        }

        public void Handle(UpdateProductCommand command)
        {
            var product = _productRepository.GetById(command.Id);

            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;
            product.DeliveryPrice = command.DeliveryPrice;

            Commit();
        }
    }
}
