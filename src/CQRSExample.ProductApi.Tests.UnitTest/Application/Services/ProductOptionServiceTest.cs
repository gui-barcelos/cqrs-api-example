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
using CQRSExample.ProductApi.Domain.Commands.ProductOption;

namespace CQRSExample.ProductApi.Tests.UnitTest.Application.Services
{
    [TestClass]
    public class ProductOptionServiceTest
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
        public async Task CreateProductOptionShouldReturnExeptionWhenCommandFail()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<CreateProductOptionCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Exception error!"));

            // Act
            var service = new ProductOptionService(_mapper.Object, _mediator.Object);

            var result = await service.CreateProductOption(new CreateProductOptionCommand(Guid.NewGuid(), "name", "desc"));

            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.AreEqual(result.FailureReason, "Exception error!");
        }

        [TestMethod]
        public async Task CreateProductOptionShouldReturnGroupedValidationExeptionWhenCommandFail()
        {
            // Arrange
            var validationExceptions = new List<ValidationFailure>()
            {
                new ValidationFailure("p1", "error p1"),
                new ValidationFailure("p2", "error p2")
            };
            _mediator.Setup(e => e.Send(It.IsAny<CreateProductOptionCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new ValidationException(validationExceptions));

            // Act
            var service = new ProductOptionService(_mapper.Object, _mediator.Object);

            var result = await service.CreateProductOption(new CreateProductOptionCommand(Guid.NewGuid(), "name", "desc"));
            
            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.IsTrue(result.FailureReason.Contains("error p1"));
            Assert.IsTrue(result.FailureReason.Contains("error p2"));
        }

        [TestMethod]
        public async Task CreateProductOptionShouldReturnSuccessWhenCommandSuccess()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<CreateProductOptionCommand>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            // Act
            var service = new ProductOptionService(_mapper.Object, _mediator.Object);

            var result = await service.CreateProductOption(new CreateProductOptionCommand(Guid.NewGuid(), "name", "desc"));

            // Assert
            Assert.AreEqual(result.IsSuccess, true);
        }

        [TestMethod]
        public async Task UpdateProductOptionShouldReturnExeptionWhenCommandFail()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<UpdateProductOptionCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Exception error!"));

            // Act
            var service = new ProductOptionService(_mapper.Object, _mediator.Object);

            var result = await service.UpdateProductOption(new UpdateProductOptionCommand(Guid.NewGuid(),"name", "desc"));

            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.AreEqual(result.FailureReason, "Exception error!");
        }

        [TestMethod]
        public async Task UpdateProductOptionShouldReturnSuccessWhenCommandSuccess()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<UpdateProductOptionCommand>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            // Act
            var service = new ProductOptionService(_mapper.Object, _mediator.Object);

            var result = await service.UpdateProductOption(new UpdateProductOptionCommand(Guid.NewGuid(), "name", "desc"));

            // Assert
            Assert.AreEqual(result.IsSuccess, true);
        }

        [TestMethod]
        public async Task UpdateProductOptionShouldReturnGroupedValidationExeptionWhenCommandFail()
        {
            // Arrange
            var validationExceptions = new List<ValidationFailure>()
            {
                new ValidationFailure("p1", "error p1"),
                new ValidationFailure("p2", "error p2")
            };
            _mediator.Setup(e => e.Send(It.IsAny<UpdateProductOptionCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new ValidationException(validationExceptions));

            // Act
            var service = new ProductOptionService(_mapper.Object, _mediator.Object);

            var result = await service.UpdateProductOption(new UpdateProductOptionCommand(Guid.NewGuid(), "name", "desc"));

            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.IsTrue(result.FailureReason.Contains("error p1"));
            Assert.IsTrue(result.FailureReason.Contains("error p2"));
        }

        [TestMethod]
        public async Task DeleteProductOptionShouldReturnExeptionWhenCommandFail()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<DeleteProductOptionCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new Exception("Exception error!"));

            // Act
            var service = new ProductOptionService(_mapper.Object, _mediator.Object);

            var result = await service.DeleteProductOption(new DeleteProductOptionCommand(Guid.NewGuid()));

            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.AreEqual(result.FailureReason, "Exception error!");
        }

        [TestMethod]
        public async Task DeleteProductOptionShouldReturnSuccessWhenCommandSuccess()
        {
            // Arrange
            _mediator.Setup(e => e.Send(It.IsAny<DeleteProductOptionCommand>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

            // Act
            var service = new ProductOptionService(_mapper.Object, _mediator.Object);

            var result = await service.DeleteProductOption(new DeleteProductOptionCommand(Guid.NewGuid()));

            // Assert
            Assert.AreEqual(result.IsSuccess, true);
        }

        [TestMethod]
        public async Task DeleteProductOptionShouldReturnGroupedValidationExeptionWhenCommandFail()
        {
            // Arrange
            var validationExceptions = new List<ValidationFailure>()
            {
                new ValidationFailure("p1", "error p1"),
                new ValidationFailure("p2", "error p2")
            };
            _mediator.Setup(e => e.Send(It.IsAny<DeleteProductOptionCommand>(), It.IsAny<CancellationToken>())).ThrowsAsync(new ValidationException(validationExceptions));

            // Act
            var service = new ProductOptionService(_mapper.Object, _mediator.Object);

            var result = await service.DeleteProductOption(new DeleteProductOptionCommand(Guid.NewGuid()));

            // Assert
            Assert.AreEqual(result.IsSuccess, false);
            Assert.IsTrue(result.FailureReason.Contains("error p1"));
            Assert.IsTrue(result.FailureReason.Contains("error p2"));
        }
    }
}
