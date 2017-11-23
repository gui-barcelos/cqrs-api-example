using System.Linq;
using MediatR;
using CQRSExample.ProductApi.Domain.Model;
using CQRSExample.ProductApi.Domain.Queries.ProductOption;
using CQRSExample.ProductApi.Domain.Repository.Interfaces;

namespace CQRSExample.ProductApi.Domain.QueryHandler.Product
{
    public class ProductOptionQueryHandler : IRequestHandler<GetAllProductOptionsQuery, IQueryable<Model.ProductOption>>,
                                            IRequestHandler<GetProductOptionQuery, Model.ProductOption>
    {
        private readonly IProductOptionRepository _productOptionRepository;

        public ProductOptionQueryHandler(IProductOptionRepository productOptionRepository)
        {
            _productOptionRepository = productOptionRepository;
        }

        public IQueryable<Model.ProductOption> Handle(GetAllProductOptionsQuery message)
        {
            return _productOptionRepository.GetByPredicate(e => e.Product.Id == message.ProductId);
        }

        public ProductOption Handle(GetProductOptionQuery message)
        {
            return _productOptionRepository.GetById(message.Id);
        }
    }
}
