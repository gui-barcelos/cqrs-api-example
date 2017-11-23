using System;

namespace CQRSExample.ProductApi.Domain.Model
{
    public class ProductOption
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
