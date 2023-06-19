using CatalogServiceNetAdvanced.Application.Common.Mappings;
using CatalogServiceNetAdvanced.Domain.Entities;

namespace CatalogServiceNetAdvanced.Application.ProductItems.Queries
{
    public class ProductItemBriefDto : IMapFrom<ProductItem>
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public string? Image { get; init; }
        public int CategoryId { get; init; }
        public string? Price { get; init; }
        public int Amount { get; init; }
    }
}