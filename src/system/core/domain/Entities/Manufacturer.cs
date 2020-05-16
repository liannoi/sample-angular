using System.Collections.Generic;

namespace SampleAngular.Domain.Entities
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Products = new HashSet<Product>();
        }

        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}