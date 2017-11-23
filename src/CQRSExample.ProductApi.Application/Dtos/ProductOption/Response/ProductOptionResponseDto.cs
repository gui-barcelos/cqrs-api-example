using System;

namespace CQRSExample.ProductApi.Business.Dtos.ProductOption.Response
{
    public class ProductOptionResponseDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
