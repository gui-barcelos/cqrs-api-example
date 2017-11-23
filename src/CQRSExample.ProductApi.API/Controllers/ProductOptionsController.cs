using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CQRSExample.ProductApi.Business.Dtos.ProductOption.Request;
using CQRSExample.ProductApi.Business.Dtos.ProductOption.Response;
using CQRSExample.ProductApi.Business.Interfaces;
using CQRSExample.ProductApi.Domain.Commands.ProductOption;

namespace CQRSExample.ProductApi.API.Controllers
{
    [RoutePrefix("products/{productId:guid}")]
    public class ProductOptionsController : ApiController
    {
        private readonly IProductOptionService _productOptionService;
        public ProductOptionsController(IProductOptionService productOptionService)
        {
            _productOptionService = productOptionService;
        }

        /// <summary>
        /// Finds all options for a specified product.
        /// </summary>
        /// <param name="productId">Product Id</param>
        [Route("options")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProductOptionsResponseDto>))]
        public async Task<IHttpActionResult> GetOptions(Guid productId)
        {
            var response = await _productOptionService.GetAllByProductId(productId);

            if (!response.IsSuccess)
                return BadRequest(response.FailureReason);

            return Ok(response.Result);
        }

        /// <summary>
        /// Finds the specified product option for the specified product.
        /// </summary>
        /// <param name="id">Product Option Id</param>
        [Route("options/{id:guid}")]
        [HttpGet]
        [ResponseType(typeof(ProductOptionResponseDto))]
        public async Task<IHttpActionResult> GetOption(Guid id)
        {
            var response = await _productOptionService.GetById(id);

            if (!response.IsSuccess)
                return BadRequest(response.FailureReason);

            if (response.Result == null)
                return NotFound();

            return Ok(response.Result);
        }

        /// <summary>
        /// Adds a new product option to the specified product.
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="requestDto">Product Option Id</param>
        /// <returns></returns>
        [Route("options")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateOption(Guid productId, ProductOptionRequestDto requestDto)
        {
            var command = new CreateProductOptionCommand(productId, requestDto.Name, requestDto.Description);

            var result = await _productOptionService.CreateProductOption(command);

            if (!result.IsSuccess)
                return BadRequest(result.FailureReason);

            return Ok();

        }

        /// <summary>
        /// Updates the specified product option.
        /// </summary>
        /// <param name="id">Product Option Id</param>
        /// <param name="requestDto">Product Option Request DTO</param>
        [Route("options/{id:guid}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateOption(Guid id, ProductOptionRequestDto requestDto)
        {
            var command = new UpdateProductOptionCommand(id, requestDto.Name, requestDto.Description);

            var result = await _productOptionService.UpdateProductOption(command);

            if (!result.IsSuccess)
                return BadRequest(result.FailureReason);

            return Ok();
        }

        /// <summary>
        /// Deletes the specified product option.
        /// </summary>
        /// <param name="id">Product Option Id</param>
        [Route("options/{id:guid}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOption(Guid id)
        {
            var command = new DeleteProductOptionCommand(id);

            await _productOptionService.DeleteProductOption(command);

            return Ok();
        }
    }
}