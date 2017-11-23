using System.Linq;
using MediatR;
using CQRSExample.ProductApi.Domain.Queries.Product;
using CQRSExample.ProductApi.Domain.Repository.Interfaces;

namespace CQRSExample.ProductApi.Domain.QueryHandler.Product
{
    public class ProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IQueryable<Model.Product>>,
                                        IRequestHandler<GetProductByIdQuery, Model.Product>,
                                        IRequestHandler<SearchProductByNameQuery, IQueryable<Model.Product>>
    {
        private readonly IProductRepository _productRepository;

        public ProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IQueryable<Model.Product> Handle(GetAllProductsQuery message)
        {
            return _productRepository.GetAll();
        }

        public Model.Product Handle(GetProductByIdQuery message)
        {
            return _productRepository.GetById(message.Id);
        }

        public IQueryable<Model.Product> Handle(SearchProductByNameQuery message)
        {
            return _productRepository.GetByPredicate(e => e.Name.ToLower().Contains(message.Name.ToLower()));
        }
    }
}
