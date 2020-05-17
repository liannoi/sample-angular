using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Infrastructure.Persistence.Configurations
{
    public class ProductPhotoConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.HasKey(e => new {e.PhotoId, e.ProductId}).HasName("PK_Photos");
            builder.Property(e => e.PhotoId).ValueGeneratedOnAdd();
            builder.Property(e => e.Path).IsRequired().HasMaxLength(256);

            builder.HasOne(d => d.Product)
                .WithMany(p => p.ProductPhotos)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Photos_ProductId");
        }
    }
}