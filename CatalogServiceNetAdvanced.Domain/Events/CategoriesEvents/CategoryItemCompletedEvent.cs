using CatalogServiceNetAdvanced.Domain.Common;
using CatalogServiceNetAdvanced.Domain.Entities;

namespace CatalogServiceNetAdvanced.Domain.Events.CategoriesEvents
{
    public class CategoryItemCompletedEvent : BaseEvent
    {
        public CategoryItemCompletedEvent(CategoryItem item)
        {
            Item = item;
        }

        public CategoryItem Item { get; }
    }
}