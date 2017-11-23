using System;
using System.Threading.Tasks;
using CQRSExample.ProductApi.Application.Dtos.Query.Response;
using CQRSExample.ProductApi.Business.Dtos.Command.Response;
using CQRSExample.ProductApi.Business.Dtos.ProductOption.Response;
using CQRSExample.ProductApi.Domain.Commands.ProductOption;

namespace CQRSExample.ProductApi.Business.Interfaces
{
    public interface IProductOptionService
    {
        Task<QueryResponseDto<ProductOptionsResponseDto>> GetAllByProductId(Guid productId);
        Task<QueryResponseDto<ProductOptionResponseDto>> GetById(Guid id);
        Task<CommandResponseDto> CreateProductOption(CreateProductOptionCommand command);
        Task<CommandResponseDto> UpdateProductOption(UpdateProductOptionCommand command);
        Task<CommandResponseDto> DeleteProductOption(DeleteProductOptionCommand command);
    }
}
