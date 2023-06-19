using CatalogServiceNetAdvanced.Application.Common.Mappings;
using CatalogServiceNetAdvanced.Domain.Entities;

namespace CatalogServiceNetAdvanced.Application.CategoryItems.Queries
{
    public class CategoryItemBriefDto : IMapFrom<CategoryItem>
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Image { get; init; }
        public int ParentId { get; init; }
    }
}