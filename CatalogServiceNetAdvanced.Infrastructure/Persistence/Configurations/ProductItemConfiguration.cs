using CatalogServiceNetAdvanced.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceNetAdvanced.Infrastructure.Persistence.Configurations
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.CategoryId)
                .IsRequired();
            builder.Property(t => t.Price)
                .IsRequired();
            builder.Property(t => t.Amount)
                .IsRequired();
        }
    }
}