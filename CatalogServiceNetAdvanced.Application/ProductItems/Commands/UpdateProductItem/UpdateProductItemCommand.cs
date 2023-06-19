using CatalogServiceNetAdvanced.Application.Common.Interfaces;
using MediatR;

namespace CatalogServiceNetAdvanced.Application.ProductItems.Commands.UpdateProductItem
{
    public record UpdateProductItemCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public string? Image { get; init; }
        public int CategoryId { get; init; }
        public string? Price { get; init; }
        public int Amount { get; init; }
        public bool Done { get; init; }
    }

    public class UpdateProductItemCommandHandler : IRequestHandler<UpdateProductItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateProductItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new Exception();
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Image = request.Image;
            entity.CategoryId = request.CategoryId;
            entity.Price = request.Price;
            entity.Amount = request.Amount;
            entity.Done = request.Done;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}