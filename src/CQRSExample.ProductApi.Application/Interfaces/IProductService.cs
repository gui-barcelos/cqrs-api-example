using System;
using System.Threading.Tasks;
using CQRSExample.ProductApi.Application.Dtos.Query.Response;
using CQRSExample.ProductApi.Business.Dtos.Command.Response;
using CQRSExample.ProductApi.Business.Dtos.Product.Response;
using CQRSExample.ProductApi.Domain.Commands.Product;

namespace CQRSExample.ProductApi.Business.Interfaces
{
    public interface IProductService
    {
        Task<QueryResponseDto<ProductsResponseDto>> GetAll();
        Task<QueryResponseDto<ProductsResponseDto>> SearchByName(string name);
        Task<QueryResponseDto<ProductResponseDto>> GetById(Guid id);
        Task<CommandResponseDto> CreateProduct(CreateProductCommand command);
        Task<CommandResponseDto> UpdateProduct(UpdateProductCommand command);
        Task<CommandResponseDto> DeleteProduct(DeleteProductCommand command);
    }
}
