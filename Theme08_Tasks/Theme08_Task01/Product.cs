namespace Theme08_Task01
{
    public enum ProductCategory
    {
        Food,
        Appliances
    }

    public class Product
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public string? ImagePath { get; set; }
    }
}
