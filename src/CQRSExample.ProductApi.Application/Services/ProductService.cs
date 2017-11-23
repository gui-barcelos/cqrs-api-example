using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using CQRSExample.ProductApi.Business.Dtos.Command.Response;
using CQRSExample.ProductApi.Business.Dtos.Product.Response;
using CQRSExample.ProductApi.Business.Interfaces;
using CQRSExample.ProductApi.Domain.Commands.Product;
using CQRSExample.ProductApi.Domain.Queries.Product;
using CQRSExample.ProductApi.Application.Dtos.Query.Response;

namespace CQRSExample.ProductApi.Business.Services
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        public async Task<QueryResponseDto<ProductsResponseDto>> GetAll()
        {
            try
            {
                var products = await _mediator.Send(new GetAllProductsQuery());

                var response = new ProductsResponseDto()
                {
                    Items = products.ProjectTo<ProductResponseDto>(_mapper.ConfigurationProvider)
                };

                return QueryResponseDto<ProductsResponseDto>.Success(response);
            }
            catch (Exception ex)
            {
                return QueryResponseDto<ProductsResponseDto>.Fail(GetErrorMessage(ex));
            }
        }

        public async Task<QueryResponseDto<ProductsResponseDto>> SearchByName(string name)
        {
            try
            {
                var products = await _mediator.Send(new SearchProductByNameQuery(name));

                var response = new ProductsResponseDto()
                {
                    Items = products.ProjectTo<ProductResponseDto>(_mapper.ConfigurationProvider)
                };

                return QueryResponseDto<ProductsResponseDto>.Success(response);
            }
            catch (Exception ex)
            {
                return QueryResponseDto<ProductsResponseDto>.Fail(GetErrorMessage(ex));
            }
        }

        public async Task<QueryResponseDto<ProductResponseDto>> GetById(Guid id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductByIdQuery(id));

                return QueryResponseDto<ProductResponseDto>.Success(_mapper.Map<ProductResponseDto>(product));
            }
            catch (Exception ex)
            {
                return QueryResponseDto<ProductResponseDto>.Fail(GetErrorMessage(ex));
            }
        }

        public async Task<CommandResponseDto> CreateProduct(CreateProductCommand command)
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

        public async Task<CommandResponseDto> UpdateProduct(UpdateProductCommand command)
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

        public async Task<CommandResponseDto> DeleteProduct(DeleteProductCommand command)
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
