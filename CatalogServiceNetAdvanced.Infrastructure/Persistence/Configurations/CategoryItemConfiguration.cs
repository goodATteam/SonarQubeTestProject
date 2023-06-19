using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CatalogServiceNetAdvanced.Domain.Entities;

namespace CatalogServiceNetAdvanced.Infrastructure.Persistence.Configurations
{
    public class CategoryItemConfiguration : IEntityTypeConfiguration<CategoryItem>
    {
        public void Configure(EntityTypeBuilder<CategoryItem> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}