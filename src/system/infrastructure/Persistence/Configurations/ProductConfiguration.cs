using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(e => e.ProductId);
            builder.HasIndex(e => e.Name).HasName("UNQ_Products_Name").IsUnique();
            builder.HasIndex(e => e.ProductNumber).HasName("UNQ_Products_ProductNumber").IsUnique();
            builder.Property(e => e.Name).IsRequired().HasMaxLength(32);
            builder.Property(e => e.ProductNumber).IsRequired().HasMaxLength(15).IsUnicode(false);

            builder.HasOne(d => d.Manufacturer)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products");
        }
    }
}