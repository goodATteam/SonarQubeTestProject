using CatalogServiceNetAdvanced.Application.Common.Interfaces;
using CatalogServiceNetAdvanced.Domain.Entities;
using CatalogServiceNetAdvanced.Domain.Events.CategoriesEvents;
using MediatR;

namespace CatalogServiceNetAdvanced.Application.CategoryItems.Commands.CreateCategoryItem
{
    public record CreateCategoryItemCommand : IRequest<int>
    {
        public string? Name { get; init; }
        public string? Image { get; init; }
        public int ParentId { get; init; }
    }

    public class CreateCategoryItemCommandHandler : IRequestHandler<CreateCategoryItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCategoryItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCategoryItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new CategoryItem
            {
                Name = request.Name,
                Image = request.Image,
                ParentId = request.ParentId,
                Done = false
            };

            entity.AddDomainEvent(new CategoryItemCreatedEvent(entity));

            _context.CategoryItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}