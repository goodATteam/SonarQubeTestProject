using AutoMapper;
using AutoMapper.QueryableExtensions;
using CatalogServiceNetAdvanced.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogServiceNetAdvanced.Application.CategoryItems.Queries
{
    public record GetCategoryItemsQuery : IRequest<CategoryItemsDto>;

    public class GetCategoryItemsQueryHandler : IRequestHandler<GetCategoryItemsQuery, CategoryItemsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryItemsDto> Handle(GetCategoryItemsQuery request, CancellationToken cancellationToken)
        {
            var tempCategoryList =  await _context.CategoryItems
                .ProjectTo<CategoryItemBriefDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new CategoryItemsDto
            {
                Items = tempCategoryList
            };
        }
    }
}