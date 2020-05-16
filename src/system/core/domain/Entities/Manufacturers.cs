using System.Collections.Generic;

namespace SampleAngular.Domain.Entities
{
    public class Manufacturers
    {
        public Manufacturers()
        {
            Products = new HashSet<Products>();
        }

        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}