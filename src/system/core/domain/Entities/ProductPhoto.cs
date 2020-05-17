namespace SampleAngular.Domain.Entities
{
    public class ProductPhoto
    {
        public int PhotoId { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }

        public Product Product { get; set; }
    }
}