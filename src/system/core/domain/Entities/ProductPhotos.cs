namespace SampleAngular.Domain.Entities
{
    public class ProductPhotos
    {
        public int PhotoId { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }

        public Products Product { get; set; }
    }
}