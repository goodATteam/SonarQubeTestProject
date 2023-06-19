using AutoMapper;
using AutoMapper.QueryableExtensions;
using CatalogServiceNetAdvanced.Application.Common.Interfaces;
using CatalogServiceNetAdvanced.Application.Common.Mappings;
using CatalogServiceNetAdvanced.Application.Common.Models;
using MediatR;

namespace CatalogServiceNetAdvanced.Application.ProductItems.Queries
{
    public record GetProductItemsWithPaginationQuery : IRequest<PaginatedList<ProductItemBriefDto>>
    {
        public int CategoryId { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 2;

    }

    public class GetProductItemsQueryHandler : IRequestHandler<GetProductItemsWithPaginationQuery, PaginatedList<ProductItemBriefDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ProductItemBriefDto>> Handle(GetProductItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return  await _context.ProductItems
                .Where(x => x.CategoryId == request.CategoryId)
                .ProjectTo<ProductItemBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}