using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CQRSExample.ProductApi.Domain.CommandHandler;
using CQRSExample.ProductApi.Domain.Commands.Product;
using CQRSExample.ProductApi.Domain.Interfaces.UnitOfWork;
using CQRSExample.ProductApi.Domain.Model;
using CQRSExample.ProductApi.Domain.Repository.Interfaces;

namespace CQRSExample.ProductApi.Tests.UnitTest.Domain.CommandHandler
{
    [TestClass]
    public class ProductCommandHandlerTests
    {
        private Mock<IUnitOfWork> _uow;
        private Mock<IProductRepository> _productRepository;

        [TestInitialize]
        public void Initialize()
        {
            _uow = new Mock<IUnitOfWork>();
            _productRepository = new Mock<IProductRepository>();
        }

        [TestMethod]
        public void DeleteProductCommandHandlerShouldCallCommit()
        {
            // Arrange 
            _productRepository.Setup(e => e.Remove(It.IsAny<Guid>()));

            // Act
            var commandHandler = new ProductCommandHandler(_uow.Object, _productRepository.Object);
            commandHandler.Handle(new DeleteProductCommand(Guid.NewGuid()));

            // Assert
            _uow.Verify(o => o.Commit(), Times.Once());
        }

        [TestMethod]
        public void CreateProductCommandHandlerShouldCallCommit()
        {
            // Arrange 
            _productRepository.Setup(e => e.Add(It.IsAny<Product>()));

            // Act
            var commandHandler = new ProductCommandHandler(_uow.Object, _productRepository.Object);
            commandHandler.Handle(new CreateProductCommand("name", "desc", 1 , 1));

            // Assert
            _uow.Verify(o => o.Commit(), Times.Once());
        }

        [TestMethod]
        public void UpdateProductCommandHandlerShouldCallCommit()
        {
            // Arrange 
            _productRepository.Setup(e => e.GetById(It.IsAny<Guid>())).Returns(new Product());
            _productRepository.Setup(e => e.Update(It.IsAny<Product>()));

            // Act
            var commandHandler = new ProductCommandHandler(_uow.Object, _productRepository.Object);
            commandHandler.Handle(new UpdateProductCommand(Guid.NewGuid(), "name", "desc", 1, 1));

            // Assert
            _uow.Verify(o => o.Commit(), Times.Once());
        }
    }
}
