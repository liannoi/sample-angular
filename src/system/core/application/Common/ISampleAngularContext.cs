using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Common
{
    public interface ISampleAngularContext
    {
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<ProductPhoto> ProductPhotos { get; set; }
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}