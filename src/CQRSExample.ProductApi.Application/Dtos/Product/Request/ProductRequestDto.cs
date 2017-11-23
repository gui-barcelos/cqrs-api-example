namespace CQRSExample.ProductApi.Business.Dtos.Product.Request
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
