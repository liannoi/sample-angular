using System.Collections.Generic;

namespace SampleAngular.Domain.Entities
{
    public class Products
    {
        public Products()
        {
            ProductPhotos = new HashSet<ProductPhotos>();
        }

        public int ProductId { get; set; }
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }

        public Manufacturers Manufacturer { get; set; }
        public ICollection<ProductPhotos> ProductPhotos { get; set; }
    }
}