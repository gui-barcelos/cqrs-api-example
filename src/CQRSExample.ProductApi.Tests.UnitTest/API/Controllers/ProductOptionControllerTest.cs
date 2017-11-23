using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using System.Web.Http.Results;
using CQRSExample.ProductApi.API.Controllers;
using CQRSExample.ProductApi.Application.Dtos.Query.Response;
using CQRSExample.ProductApi.Business.Dtos.Command.Response;
using CQRSExample.ProductApi.Business.Dtos.ProductOption.Request;
using CQRSExample.ProductApi.Business.Dtos.ProductOption.Response;
using CQRSExample.ProductApi.Business.Interfaces;
using CQRSExample.ProductApi.Domain.Commands.ProductOption;

namespace CQRSExample.ProductApi.Tests.UnitTest.API.Controllers
{
    [TestClass]
    public class ProductOptionControllerTest
    {
        protected Mock<IProductOptionService> _productOptionService;

        [TestInitialize]
        public void Initialize()
        {
            _productOptionService = new Mock<IProductOptionService>();
        }

        [TestMethod]
        public async Task GetoOptionsShouldReturnResponseDto()
        {
            // Arrange
            _productOptionService.Setup(x => x.GetAllByProductId(It.IsAny<Guid>())).ReturnsAsync(new QueryResponseDto<ProductOptionsResponseDto>(new ProductOptionsResponseDto()));

            var controller = new ProductOptionsController(_productOptionService.Object);

            // Act
            var response = await controller.GetOptions(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<ProductOptionsResponseDto>));
        }

        [TestMethod]
        public async Task GetoOptionsShouldBadRequestWhenFail()
        {
            // Arrange
            _productOptionService.Setup(x => x.GetAllByProductId(It.IsAny<Guid>())).ReturnsAsync(new QueryResponseDto<ProductOptionsResponseDto>("Error!"));

            var controller = new ProductOptionsController(_productOptionService.Object);

            // Act
            var response = await controller.GetOptions(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(((BadRequestErrorMessageResult)response).Message, "Error!");
        }

        [TestMethod]
        public async Task GetOptionShouldReturnResponseDto()
        {
            // Arrange
            _productOptionService.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new QueryResponseDto<ProductOptionResponseDto>(new ProductOptionResponseDto()));

            var controller = new ProductOptionsController(_productOptionService.Object);

            // Act
            var response = await controller.GetOption(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkNegotiatedContentResult<ProductOptionResponseDto>));
        }

        [TestMethod]
        public async Task GetOptionShouldBadRequestWhenFail()
        {
            // Arrange
            _productOptionService.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new QueryResponseDto<ProductOptionResponseDto>("Error!"));

            var controller = new ProductOptionsController(_productOptionService.Object);

            // Act
            var response = await controller.GetOption(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(((BadRequestErrorMessageResult)response).Message, "Error!");
        }

        [TestMethod]
        public async Task CreateProductOptionShouldReturnErrorWhenFail()
        {
            // Arrange
            _productOptionService.Setup(x => x.CreateProductOption(It.IsAny<CreateProductOptionCommand>())).ReturnsAsync(CommandResponseDto.Fail("Error message!"));

            var controller = new ProductOptionsController(_productOptionService.Object);

            // Act
            var response = await controller.CreateOption(Guid.NewGuid(), new ProductOptionRequestDto());

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(((BadRequestErrorMessageResult)response).Message, "Error message!");
        }

        [TestMethod]
        public async Task CreateProductShouldReturnOkWhenSuccess()
        {
            // Arrange
            _productOptionService.Setup(x => x.CreateProductOption(It.IsAny<CreateProductOptionCommand>())).ReturnsAsync(CommandResponseDto.Success);

            var controller = new ProductOptionsController(_productOptionService.Object);

            // Act
            var response = await controller.CreateOption(Guid.NewGuid(), new ProductOptionRequestDto());

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }

        [TestMethod]
        public async Task UpdateProductShouldReturnErrorWhenFail()
        {
            // Arrange
            _productOptionService.Setup(x => x.UpdateProductOption(It.IsAny<UpdateProductOptionCommand>())).ReturnsAsync(CommandResponseDto.Fail("Error update message!"));

            var controller = new ProductOptionsController(_productOptionService.Object);

            // Act
            var response = await controller.UpdateOption(Guid.NewGuid(), new ProductOptionRequestDto());

            // Assert
            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual(((BadRequestErrorMessageResult)response).Message, "Error update message!");
        }

        [TestMethod]
        public async Task UpdateProductShouldReturnOkWhenSuccess()
        {
            // Arrange
            _productOptionService.Setup(x => x.UpdateProductOption(It.IsAny<UpdateProductOptionCommand>())).ReturnsAsync(CommandResponseDto.Success);

            var controller = new ProductOptionsController(_productOptionService.Object);

            // Act
            var response = await controller.UpdateOption(Guid.NewGuid(), new ProductOptionRequestDto());

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }

        [TestMethod]
        public async Task DeleteProductShouldReturnOkWhenSuccess()
        {
            // Arrange
            _productOptionService.Setup(x => x.DeleteProductOption(It.IsAny<DeleteProductOptionCommand>())).ReturnsAsync(CommandResponseDto.Success);

            var controller = new ProductOptionsController(_productOptionService.Object);

            // Act
            var response = await controller.DeleteOption(Guid.NewGuid());

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkResult));
        }
    }
}
