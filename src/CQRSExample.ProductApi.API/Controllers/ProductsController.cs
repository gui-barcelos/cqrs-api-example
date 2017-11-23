using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CQRSExample.ProductApi.Business.Dtos.Product.Request;
using CQRSExample.ProductApi.Business.Dtos.Product.Response;
using CQRSExample.ProductApi.Business.Interfaces;
using CQRSExample.ProductApi.Domain.Commands.Product;

namespace CQRSExample.ProductApi.API.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        [Route]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProductsResponseDto>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var response = await _productService.GetAll();

            if (!response.IsSuccess)
                return BadRequest(response.FailureReason);

            return Ok(response.Result);
        }

        /// <summary>
        /// Finds all products matching the specified name.
        /// </summary>
        /// <param name="name">Name for matching</param>
        [Route("{name}")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProductsResponseDto>))]

        public async Task<IHttpActionResult> SearchByName(string name)
        {
            var response = await _productService.SearchByName(name);

            if (!response.IsSuccess)
                return BadRequest(response.FailureReason);

            return Ok(response.Result);
        }

        /// <summary>
        /// Gets the product that matches the specified ID.
        /// </summary>
        /// <param name="id">ID</param>
        [Route("{id:guid}")]
        [HttpGet]
        [ResponseType(typeof(ProductResponseDto))]
        public async Task<IHttpActionResult> GetProduct(Guid id)
        {
            var response = await _productService.GetById(id);

            if (!response.IsSuccess)
                return BadRequest(response.FailureReason);

            if (response.Result == null)
                return NotFound();

            return Ok(response.Result);
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="requestDto">Product Requese DTO</param>
        [Route]
        [HttpPost]
        public async Task<IHttpActionResult> Create(ProductRequestDto requestDto)
        {
            var command = new CreateProductCommand(requestDto.Name, requestDto.Description, requestDto.Price, requestDto.DeliveryPrice);

            var result = await _productService.CreateProduct(command);

            if (!result.IsSuccess)
                return BadRequest(result.FailureReason);

            return Ok();
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="requestDto">Product Requese DTO</param>
        [Route("{id:guid}")]
        [HttpPut]
        public async Task<IHttpActionResult> Update(Guid id, ProductRequestDto requestDto)
        {
            var command = new UpdateProductCommand(id, requestDto.Name, requestDto.Description, requestDto.Price, requestDto.DeliveryPrice);

            var result = await _productService.UpdateProduct(command);

            if (!result.IsSuccess)
                return BadRequest(result.FailureReason);

            return Ok();
        }

        /// <summary>
        /// Deletes a product and its options.
        /// </summary>
        /// <param name="id">Product Id</param>
        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand(id);

            await _productService.DeleteProduct(command);

            return Ok();
        }
    }
}
