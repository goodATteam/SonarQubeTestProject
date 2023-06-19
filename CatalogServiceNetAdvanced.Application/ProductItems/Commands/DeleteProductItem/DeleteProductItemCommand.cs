using CatalogServiceNetAdvanced.Application.Common.Interfaces;
using CatalogServiceNetAdvanced.Domain.Events.ProductsEvents;
using MediatR;

namespace CatalogServiceNetAdvanced.Application.ProductItems.Commands.DeleteProductItem
{
    public record DeleteProductItemCommand(int Id) : IRequest;
    public class DeleteProductItemCommandHandler : IRequestHandler<DeleteProductItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteProductItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductItems.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new Exception();
            }

            _context.ProductItems.Remove(entity);

            entity.AddDomainEvent(new ProductItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}