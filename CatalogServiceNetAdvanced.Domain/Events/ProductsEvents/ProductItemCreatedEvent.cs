using CatalogServiceNetAdvanced.Domain.Common;
using CatalogServiceNetAdvanced.Domain.Entities;

namespace CatalogServiceNetAdvanced.Domain.Events.ProductsEvents
{
    public class ProductItemCreatedEvent : BaseEvent
    {
        public ProductItemCreatedEvent(ProductItem item)
        {
            Item = item;
        }

        public ProductItem Item { get; }
    }
}