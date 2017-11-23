using System.Collections.Generic;

namespace CQRSExample.ProductApi.Business.Dtos.Product.Response
{
    public class ProductsResponseDto
    {
        public IEnumerable<ProductResponseDto> Items { get; set; }
    }
}
