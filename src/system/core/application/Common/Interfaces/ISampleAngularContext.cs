using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Common.Interfaces
{
    public interface ISampleAngularContext
    {
        DbSet<Manufacturers> Manufacturers { get; set; }
        DbSet<ProductPhotos> ProductPhotos { get; set; }
        DbSet<Products> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}