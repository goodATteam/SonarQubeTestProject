using CatalogServiceNetAdvanced.Domain.Common;
using CatalogServiceNetAdvanced.Domain.Entities;

namespace CatalogServiceNetAdvanced.Domain.Events.ProductsEvents
{
    public class ProductItemCompletedEvent : BaseEvent
    {
        public ProductItemCompletedEvent(ProductItem item)
        {
            Item = item;
        }

        public ProductItem Item { get; }
    }
}