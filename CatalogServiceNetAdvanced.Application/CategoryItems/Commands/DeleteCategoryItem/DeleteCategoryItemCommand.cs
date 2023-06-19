using CatalogServiceNetAdvanced.Application.Common.Interfaces;
using CatalogServiceNetAdvanced.Domain.Events.CategoriesEvents;
using CatalogServiceNetAdvanced.Domain.Events.ProductsEvents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceNetAdvanced.Application.CategoryItems.Commands.DeleteCategoryItem
{
    public record DeleteCategoryItemCommand(int Id) : IRequest;
    public class DeleteCategoryItemCommandHandler : IRequestHandler<DeleteCategoryItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCategoryItemCommand request, CancellationToken cancellationToken)
        {
            var entityCategory = await _context.CategoryItems.FindAsync(new object[] { request.Id }, cancellationToken);            

            if (entityCategory == null)
            {
                throw new Exception();
            }
            else
            {
                var entityProducts = await _context.ProductItems.Where(x => x.CategoryId == entityCategory.Id).ToListAsync(cancellationToken);
                if (entityProducts == null)
                {
                    throw new Exception();
                }
                _context.ProductItems.RemoveRange(entityProducts);
                entityProducts.ForEach(x => x.AddDomainEvent(new ProductItemDeletedEvent(x)));
            }            

            _context.CategoryItems.Remove(entityCategory);            

            entityCategory.AddDomainEvent(new CategoryItemDeletedEvent(entityCategory));

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}