using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Infrastructure.Persistence.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturers>
    {
        public void Configure(EntityTypeBuilder<Manufacturers> builder)
        {
            builder.HasKey(e => e.ManufacturerId);
            builder.HasIndex(e => e.Name).HasName("UNQ_Manufacturers").IsUnique();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(64);
        }
    }
}