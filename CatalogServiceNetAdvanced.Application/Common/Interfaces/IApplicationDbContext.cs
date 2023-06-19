using CatalogServiceNetAdvanced.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceNetAdvanced.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<CategoryItem> CategoryItems { get; }
        DbSet<ProductItem> ProductItems { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}