using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CQRSExample.ProductApi.Domain.CommandHandler;
using CQRSExample.ProductApi.Domain.Commands.ProductOption;
using CQRSExample.ProductApi.Domain.Interfaces.UnitOfWork;
using CQRSExample.ProductApi.Domain.Model;
using CQRSExample.ProductApi.Domain.Repository.Interfaces;

namespace CQRSExample.ProductApi.Tests.UnitTest.Domain.CommandHandler
{
    [TestClass]
    public class ProductOptionCommandHandlerTests
    {
        private Mock<IUnitOfWork> _uow;
        private Mock<IProductOptionRepository> _productOptionRepository;

        [TestInitialize]
        public void Initialize()
        {
            _uow = new Mock<IUnitOfWork>();
            _productOptionRepository = new Mock<IProductOptionRepository>();
        }

        [TestMethod]
        public void DeleteProductOptionCommandHandlerShouldCallCommit()
        {
            // Arrange 
            _productOptionRepository.Setup(e => e.Remove(It.IsAny<Guid>()));

            // Act
            var commandHandler = new ProductOptionCommandHandler(_uow.Object, _productOptionRepository.Object);
            commandHandler.Handle(new DeleteProductOptionCommand(Guid.NewGuid()));

            // Assert
            _uow.Verify(o => o.Commit(), Times.Once());
        }

        [TestMethod]
        public void CreateProductOptionCommandHandlerShouldCallCommit()
        {
            // Arrange 
            _productOptionRepository.Setup(e => e.Add(It.IsAny<ProductOption>()));

            // Act
            var commandHandler = new ProductOptionCommandHandler(_uow.Object, _productOptionRepository.Object);
            commandHandler.Handle(new CreateProductOptionCommand(Guid.NewGuid(), "name", "desc"));

            // Assert
            _uow.Verify(o => o.Commit(), Times.Once());
        }

        [TestMethod]
        public void UpdateProductOptionCommandHandlerShouldCallCommit()
        {
            // Arrange 
            _productOptionRepository.Setup(e => e.GetById(It.IsAny<Guid>())).Returns(new ProductOption());
            _productOptionRepository.Setup(e => e.Update(It.IsAny<ProductOption>()));

            // Act
            var commandHandler = new ProductOptionCommandHandler(_uow.Object, _productOptionRepository.Object);
            commandHandler.Handle(new UpdateProductOptionCommand(Guid.NewGuid(), "name", "desc"));

            // Assert
            _uow.Verify(o => o.Commit(), Times.Once());
        }
    }
}
