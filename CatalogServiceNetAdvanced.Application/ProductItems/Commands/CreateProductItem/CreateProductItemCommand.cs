using CatalogServiceNetAdvanced.Application.Common.Interfaces;
using CatalogServiceNetAdvanced.Domain.Entities;
using CatalogServiceNetAdvanced.Domain.Events.ProductsEvents;
using MediatR;

namespace CatalogServiceNetAdvanced.Application.ProductItems.Commands.CreateProductItem
{
    public record CreateProductItemCommand : IRequest<int>
    {
        public string? Name { get; init; }
        public string? Description { get; init; }
        public string? Image { get; init; }
        public int CategoryId { get; init; }
        public string? Price { get; init; }
        public int Amount { get; init; }
    }

    public class CreateProductItemCommandHandler : IRequestHandler<CreateProductItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProductItem
            {
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                CategoryId = request.CategoryId,
                Price = request.Price,
                Amount = request.Amount,
                Done = false
            };

            entity.AddDomainEvent(new ProductItemCreatedEvent(entity));

            _context.ProductItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}