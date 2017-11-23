using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using CQRSExample.ProductApi.Business.Dtos.Command.Response;
using CQRSExample.ProductApi.Business.Dtos.ProductOption.Response;
using CQRSExample.ProductApi.Business.Interfaces;
using CQRSExample.ProductApi.Domain.Commands.ProductOption;
using CQRSExample.ProductApi.Domain.Queries.ProductOption;
using CQRSExample.ProductApi.Application.Dtos.Query.Response;

namespace CQRSExample.ProductApi.Business.Services
{
    public class ProductOptionService : ServiceBase, IProductOptionService
    {
        public ProductOptionService(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        public async Task<CommandResponseDto> CreateProductOption(CreateProductOptionCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                return CommandResponseDto.Fail(GetErrorMessage(ex));
            }

            return CommandResponseDto.Success;
        }

        public async Task<CommandResponseDto> DeleteProductOption(DeleteProductOptionCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                return CommandResponseDto.Fail(GetErrorMessage(ex));
            }

            return CommandResponseDto.Success;
        }

        public async Task<QueryResponseDto<ProductOptionsResponseDto>> GetAllByProductId(Guid productId)
        {
            try
            {
                var productOptions = await _mediator.Send(new GetAllProductOptionsQuery(productId));

                var response = new ProductOptionsResponseDto()
                {
                    Items = productOptions.ProjectTo<ProductOptionResponseDto>(_mapper.ConfigurationProvider)
                };

                return QueryResponseDto<ProductOptionsResponseDto>.Success(response);
            }
            catch (Exception ex)
            {
                return QueryResponseDto<ProductOptionsResponseDto>.Fail(GetErrorMessage(ex));
            }
        }

        public async Task<QueryResponseDto<ProductOptionResponseDto>> GetById(Guid id)
        {
            try
            {
                var productOption = await _mediator.Send(new GetProductOptionQuery(id));

                return QueryResponseDto<ProductOptionResponseDto>.Success(_mapper.Map<ProductOptionResponseDto>(productOption));

            }
            catch (Exception ex)
            {
                return QueryResponseDto<ProductOptionResponseDto>.Fail(GetErrorMessage(ex));
            }
        }

        public async Task<CommandResponseDto> UpdateProductOption(UpdateProductOptionCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                return CommandResponseDto.Fail(GetErrorMessage(ex));
            }

            return CommandResponseDto.Success;
        }
    }
}
