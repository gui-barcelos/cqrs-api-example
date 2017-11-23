using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using System.Web.Http.Results;
using CQRSExample.ProductApi.API.Controllers;
using CQRSExample.ProductApi.Application.Dtos.Query.Response;
using CQRSExample.ProductApi.Business.Dtos.Command.Response;
using CQRSExample.ProductApi.Business.Dtos.Product.Response;
using CQRSExample.ProductApi.Business.Interfaces;
using CQRSExample.ProductApi.Domain.Commands.Product;

namespace CQRSExample.ProductApi.Tests.UnitTest.API.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        protected Mock<IProductService> _productInterface;

        [TestInitialize]
        public void Initialize()
        {
            _productInterface = new Mock<IProductService>();
        }

        [TestMethod]
        public async Task GetAllShouldReturnProductResponseDto()
        {
            // Arrange
            _productInterface.Setup(x => x.GetAll()).ReturnsAsync(new QueryResponseDto<ProductsResponseDto>(new ProductsResponseDto()));

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<ProductsResponseDto>));
        }

        [TestMethod]
        public async Task GetAllShouldReturnBadRequestWhenFail()
        {
            // Arrange
            _productInterface.Setup(x => x.GetAll()).ReturnsAsync(new QueryResponseDto<ProductsResponseDto>("Error!"));

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(((BadRequestErrorMessageResult)response).Message, "Error!");
        }

        [TestMethod]
        public async Task SearchByNameReturnProductResponseDto()
        {
            // Arrange
            _productInterface.Setup(x => x.SearchByName(It.IsAny<string>())).ReturnsAsync(new QueryResponseDto<ProductsResponseDto>(new ProductsResponseDto()));

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.SearchByName("Samsung");

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<ProductsResponseDto>));
        }

        [TestMethod]
        public async Task SearchByNameReturnBadRequestWhenFail()
        {
            // Arrange
            _productInterface.Setup(x => x.SearchByName(It.IsAny<string>())).ReturnsAsync(new QueryResponseDto<ProductsResponseDto>("Error!"));

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.SearchByName("Samsung");

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(((BadRequestErrorMessageResult)response).Message, "Error!");
        }

        [TestMethod]
        public async Task GetProductShouldReturnNotFound()
        {
            // Arrange
            ProductResponseDto dto = null;
            var responseDto = new QueryResponseDto<ProductResponseDto>(dto);
            _productInterface.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(responseDto);

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.GetProduct(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOfType(response, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetProductShouldReturnProductResponseDto()
        {
            // Arrange
            var responseDto = new QueryResponseDto<ProductResponseDto>(new ProductResponseDto());
            _productInterface.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(responseDto);

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.GetProduct(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<ProductResponseDto>));
        }

        [TestMethod]
        public async Task GetProductShouldReturnBadRequestWhenFail()
        {
            // Arrange
            var responseDto = new QueryResponseDto<ProductResponseDto>("Error!");
            _productInterface.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(responseDto);

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.GetProduct(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(((BadRequestErrorMessageResult)response).Message, "Error!");
        }

        [TestMethod]
        public async Task CreateProductShouldReturnErrorWhenFail()
        {
            // Arrange
            _productInterface.Setup(x => x.CreateProduct(It.IsAny<CreateProductCommand>())).ReturnsAsync(CommandResponseDto.Fail("Error message!"));

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.Create(new Business.Dtos.Product.Request.ProductRequestDto());

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(((BadRequestErrorMessageResult)response).Message, "Error message!");
        }

        [TestMethod]
        public async Task CreateProductShouldReturnOkWhenSuccess()
        {
            // Arrange
            _productInterface.Setup(x => x.CreateProduct(It.IsAny<CreateProductCommand>())).ReturnsAsync(CommandResponseDto.Success);

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.Create(new Business.Dtos.Product.Request.ProductRequestDto());

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }

        [TestMethod]
        public async Task UpdateProductShouldReturnErrorWhenFail()
        {
            // Arrange
            _productInterface.Setup(x => x.UpdateProduct(It.IsAny<UpdateProductCommand>())).ReturnsAsync(CommandResponseDto.Fail("Error update message!"));

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.Update(Guid.NewGuid(), new Business.Dtos.Product.Request.ProductRequestDto());

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(((BadRequestErrorMessageResult)response).Message, "Error update message!");
        }

        [TestMethod]
        public async Task UpdateProductShouldReturnOkWhenSuccess()
        {
            // Arrange
            _productInterface.Setup(x => x.UpdateProduct(It.IsAny<UpdateProductCommand>())).ReturnsAsync(CommandResponseDto.Success);

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.Update(Guid.NewGuid(), new Business.Dtos.Product.Request.ProductRequestDto());

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }

        [TestMethod]
        public async Task DeleteProductShouldReturnOkWhenSuccess()
        {
            // Arrange
            _productInterface.Setup(x => x.DeleteProduct(It.IsAny<DeleteProductCommand>())).ReturnsAsync(CommandResponseDto.Success);

            var controller = new ProductsController(_productInterface.Object);

            // Act
            var response = await controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
