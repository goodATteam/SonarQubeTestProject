using CatalogServiceNetAdvanced.Application.Common.Interfaces;
using CatalogServiceNetAdvanced.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceNetAdvanced.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IMediator _mediator;

        public ApplicationDbContext(IMediator mediator)
        {
            _mediator = mediator;
        }

        public DbSet<CategoryItem> CategoryItems => Set<CategoryItem>();

        public DbSet<ProductItem> ProductItems => Set<ProductItem>();

        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CatalogServiceNetAdvancedDb");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}