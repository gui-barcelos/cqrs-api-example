using System.Collections.Generic;

namespace CQRSExample.ProductApi.Business.Dtos.ProductOption.Response
{
    public class ProductOptionsResponseDto
    {
        public IEnumerable<ProductOptionResponseDto> Items { get; set; }
    }
}
