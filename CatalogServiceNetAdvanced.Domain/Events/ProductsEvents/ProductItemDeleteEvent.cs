using CatalogServiceNetAdvanced.Domain.Common;
using CatalogServiceNetAdvanced.Domain.Entities;

namespace CatalogServiceNetAdvanced.Domain.Events.ProductsEvents
{
    public class ProductItemDeletedEvent : BaseEvent
    {
        public ProductItemDeletedEvent(ProductItem item)
        {
            Item = item;
        }

        public ProductItem Item { get; }
    }
}