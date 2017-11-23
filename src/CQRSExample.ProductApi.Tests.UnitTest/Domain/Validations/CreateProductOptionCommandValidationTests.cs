using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using CQRSExample.ProductApi.Domain.Commands.ProductOption;
using CQRSExample.ProductApi.Domain.Validations.Product;

namespace CQRSExample.ProductApi.Tests.UnitTest.Domain.Validations
{
    [TestClass]
    public class CreateProductOptionCommandValidationTests
    {
        private CreateProductOptionCommandValidation validator;

        [TestInitialize]
        public void Initialize()
        {
            validator = new CreateProductOptionCommandValidation();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenProductIdIsNull()
        {
            // Arrange
            var command = new CreateProductOptionCommand(Guid.Empty, "name", "desc");

            // Act
            var result = validator.Validate(command);

            // Assert 
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorMessage == "Product Id is required."));
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNameIsNull()
        {
            // Arrange
            var command = new CreateProductOptionCommand(Guid.NewGuid(), null, "desc");

            // Act
            var result = validator.Validate(command);

            // Assert 
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorMessage == "Name is required."));
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDescrptionIsNull()
        {
            // Arrange
            var command = new CreateProductOptionCommand(Guid.NewGuid(), "name", null);

            // Act
            var result = validator.Validate(command);

            // Assert 
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorMessage == "Description is required."));
        }
    }
}
