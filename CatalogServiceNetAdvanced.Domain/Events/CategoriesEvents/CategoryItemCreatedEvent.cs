using CatalogServiceNetAdvanced.Domain.Common;
using CatalogServiceNetAdvanced.Domain.Entities;

namespace CatalogServiceNetAdvanced.Domain.Events.CategoriesEvents
{
    public class CategoryItemCreatedEvent : BaseEvent
    {
        public CategoryItemCreatedEvent(CategoryItem item)
        {
            Item = item;
        }

        public CategoryItem Item { get; }
    }
}