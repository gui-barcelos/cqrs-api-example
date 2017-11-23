using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CQRSExample.ProductApi.Business.Services;
using CQRSExample.ProductApi.Domain.Commands.Product;

namespace CQRSExample.ProductApi.Tests.UnitTest.Application.Services
{
    [TestClass]
    public class ProductServiceTests
    {
        private Mock<IMapper> _mapper;
        private Mock<IMediator> _mediator;

        [TestInitialize]
        public void Initialize()
        {
            _mapper = new Mock<IMapper>();
            _mediator = new Mock<IMediator>();
        }

        [TestMethod]
        public async Task CreateProductShouldReturnExeptionWhenCommandFail()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Exception error!"));

            // Act
            var service = new ProductService(_mapper.Object, _mediator.Object);

            var result = await service.CreateProduct(new CreateProductCommand("name", "desc", 1, 1));

            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.AreEqual(result.FailureReason, "Exception error!");
        }

        [TestMethod]
        public async Task CreateProductShouldReturnGroupedValidationExeptionWhenCommandFail()
        {
            // Arrange
            var validationExceptions = new List<ValidationFailure>()
            {
                new ValidationFailure("p1", "error p1"),
                new ValidationFailure("p2", "error p2")
            };
            _mediator.Setup(e => e.Send(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new ValidationException(validationExceptions));

            // Act
            var service = new ProductService(_mapper.Object, _mediator.Object);

            var result = await service.CreateProduct(new CreateProductCommand("name", "desc", 1, 1));

            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.IsTrue(result.FailureReason.Contains("error p1"));
            Assert.IsTrue(result.FailureReason.Contains("error p2"));
        }

        [TestMethod]
        public async Task CreateProductShouldReturnSuccessWhenCommandSuccess()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            // Act
            var service = new ProductService(_mapper.Object, _mediator.Object);

            var result = await service.CreateProduct(new CreateProductCommand("name", "desc", 1, 1));

            // Assert
            Assert.AreEqual(result.IsSuccess, true);
        }

        [TestMethod]
        public async Task UpdateProductShouldReturnExeptionWhenCommandFail()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Exception error!"));

            // Act
            var service = new ProductService(_mapper.Object, _mediator.Object);

            var result = await service.UpdateProduct(new UpdateProductCommand(Guid.NewGuid(), "name", "desc", 1, 1));

            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.AreEqual(result.FailureReason, "Exception error!");
        }

        [TestMethod]
        public async Task UpdateProductShouldReturnSuccessWhenCommandSuccess()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            // Act
            var service = new ProductService(_mapper.Object, _mediator.Object);

            var result = await service.UpdateProduct(new UpdateProductCommand(Guid.NewGuid(), "name", "desc", 1, 1));

            // Assert
            Assert.AreEqual(result.IsSuccess, true);
        }

        [TestMethod]
        public async Task UpdateProductShouldReturnGroupedValidationExeptionWhenCommandFail()
        {
            // Arrange
            var validationExceptions = new List<ValidationFailure>()
            {
                new ValidationFailure("p1", "error p1"),
                new ValidationFailure("p2", "error p2")
            };
            _mediator.Setup(e => e.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new ValidationException(validationExceptions));

            // Act
            var service = new ProductService(_mapper.Object, _mediator.Object);

            var result = await service.UpdateProduct(new UpdateProductCommand(Guid.NewGuid(), "name", "desc", 1, 1));

            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.IsTrue(result.FailureReason.Contains("error p1"));
            Assert.IsTrue(result.FailureReason.Contains("error p2"));
        }

        [TestMethod]
        public async Task DeleteProductShouldReturnExeptionWhenCommandFail()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Exception error!"));

            // Act
            var service = new ProductService(_mapper.Object, _mediator.Object);

            var result = await service.DeleteProduct(new DeleteProductCommand(Guid.NewGuid()));

            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.AreEqual(result.FailureReason, "Exception error!");
        }

        [TestMethod]
        public async Task DeleteProductShouldReturnSuccessWhenCommandSuccess()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            // Act
            var service = new ProductService(_mapper.Object, _mediator.Object);

            var result = await service.DeleteProduct(new DeleteProductCommand(Guid.NewGuid()));

            // Assert
            Assert.AreEqual(result.IsSuccess, true);
        }

        [TestMethod]
        public async Task DeleteProductShouldReturnGroupedValidationExeptionWhenCommandFail()
        {
            // Arrange
            var validationExceptions = new List<ValidationFailure>()
            {
                new ValidationFailure("p1", "error p1"),
                new ValidationFailure("p2", "error p2")
            };
            _mediator.Setup(e => e.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new ValidationException(validationExceptions));

            // Act
            var service = new ProductService(_mapper.Object, _mediator.Object);

            var result = await service.DeleteProduct(new DeleteProductCommand(Guid.NewGuid()));

            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.IsTrue(result.FailureReason.Contains("error p1"));
            Assert.IsTrue(result.FailureReason.Contains("error p2"));
        }
    }
}
