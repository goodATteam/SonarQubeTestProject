using CatalogServiceNetAdvanced.Domain.Common;
using CatalogServiceNetAdvanced.Domain.Entities;

namespace CatalogServiceNetAdvanced.Domain.Events.CategoriesEvents
{
    public class CategoryItemDeletedEvent : BaseEvent
    {
        public CategoryItemDeletedEvent(CategoryItem item)
        {
            Item = item;
        }

        public CategoryItem Item { get; }
    }
}