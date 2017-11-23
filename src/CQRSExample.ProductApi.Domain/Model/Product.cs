using System;
using System.Collections;
using System.Collections.Generic;

namespace CQRSExample.ProductApi.Domain.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }

        public ICollection<ProductOption> Options { get; set; }
    }
}
