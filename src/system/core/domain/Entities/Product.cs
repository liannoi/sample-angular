using System.Collections.Generic;

namespace SampleAngular.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            ProductPhotos = new HashSet<ProductPhoto>();
        }

        public int ProductId { get; set; }
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}