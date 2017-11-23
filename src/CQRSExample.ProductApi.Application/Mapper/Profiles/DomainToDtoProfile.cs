using AutoMapper;
using CQRSExample.ProductApi.Business.Dtos.Product.Response;
using CQRSExample.ProductApi.Business.Dtos.ProductOption.Response;
using CQRSExample.ProductApi.Domain.Model;

namespace CQRSExample.ProductApi.Business.Mapper
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Product, ProductResponseDto>();
            CreateMap<ProductOption, ProductOptionResponseDto>();
        }
    }
}
