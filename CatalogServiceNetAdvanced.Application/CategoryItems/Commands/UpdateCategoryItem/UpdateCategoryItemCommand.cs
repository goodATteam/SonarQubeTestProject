using CatalogServiceNetAdvanced.Application.Common.Interfaces;
using MediatR;

namespace CatalogServiceNetAdvanced.Application.CategoryItems.Commands.UpdateCategoryItem
{
    public record UpdateCategoryItemCommand : IRequest
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Image { get; init; }
        public int ParentId { get; init; }
        public bool Done { get; init; }
    }

    public class UpdateCategoryItemCommandHandler : IRequestHandler<UpdateCategoryItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCategoryItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCategoryItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CategoryItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new Exception();
            }

            entity.Name = request.Name;
            entity.Image = request.Image;
            entity.ParentId = request.ParentId;
            entity.Done = request.Done;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}