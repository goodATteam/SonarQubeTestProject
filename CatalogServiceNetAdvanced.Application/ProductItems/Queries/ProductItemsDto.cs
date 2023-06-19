using CatalogServiceNetAdvanced.Application.CategoryItems.Queries;

namespace CatalogServiceNetAdvanced.Application.ProductItems.Queries
{
    public class ProductItemsDto
    {
        public IList<ProductItemBriefDto>? Items { get; init; }
    }
}