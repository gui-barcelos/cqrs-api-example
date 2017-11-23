using System.Data.Entity;
using CQRSExample.ProductApi.Domain.Model;

namespace CQRSExample.ProductApi.Infra.Data.Context
{
    public class ProductsContextInitializer : CreateDatabaseIfNotExists<ProductsContext>
    {
        protected override void Seed(ProductsContext context)
        {
            var samsungGalaxyS7 = new Product()
            {
                Name = "Samsung Galaxy S7",
                Description = "Newest mobile product from Samsung.",
                Price = 1024.99m,
                DeliveryPrice = 16.99m
            };

            var appleIphone6S = new Product()
            {
                Name = "Apple iPhone 6S",
                Description = "Newest mobile product from Apple.",
                Price = 1299.99m,
                DeliveryPrice = 15.99m
            };
            
            context.Product.Add(samsungGalaxyS7);
            context.Product.Add(appleIphone6S);

            var samsungGalaxyS7WhiteOption = new ProductOption()
            {
                Product = samsungGalaxyS7,
                Name = "White",
                Description = "White Samsung Galaxy S7"
            };

            var samsungGalaxyS7BlackOption = new ProductOption()
            {
                Product = samsungGalaxyS7,
                Name = "Black",
                Description = "Black Samsung Galaxy S7"
            };

            var appleIphone6SGoldOption = new ProductOption()
            {
                Product = appleIphone6S,
                Name = "Rose Gold",
                Description = "Gold Apple iPhone 6S"
            };

            var appleIphone6SWhiteOption = new ProductOption()
            {
                Product = appleIphone6S,
                Name = "White",
                Description = "White Apple iPhone 6S"
            };

            var appleIphone6SBlackOption = new ProductOption()
            {
                Product = appleIphone6S,
                Name = "Black",
                Description = "Black Apple iPhone 6S"
            };

            context.ProductOption.Add(samsungGalaxyS7WhiteOption);
            context.ProductOption.Add(samsungGalaxyS7BlackOption);
            context.ProductOption.Add(appleIphone6SGoldOption);
            context.ProductOption.Add(appleIphone6SWhiteOption);
            context.ProductOption.Add(appleIphone6SBlackOption);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
