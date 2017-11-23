using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using CQRSExample.ProductApi.API;
using CQRSExample.ProductApi.Business.Dtos.Product.Response;

namespace CQRSExample.ProductApi.Tests.IntegrationTest.API
{
    [TestClass]
    public class ProductControllerTests
    {
        private TestServer _server;

        [TestInitialize]
        public void Initialize()
        {
            _server = TestServer.Create<Startup>();
        }

        [TestCleanup]
        public void Dispose()
        {
            _server.Dispose();
        }

        [TestMethod]
        public async Task ShouldReturnAllProducts()
        {
            // Arrange
            var result = _server.HttpClient.GetAsync("/products").Result;

            // Act
            var content = await result.Content.ReadAsStringAsync();
            var output = JsonConvert.DeserializeObject<ProductsResponseDto>(content);

            // Assert
            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.IsTrue(output.Items.Any());
        }
    }
}
