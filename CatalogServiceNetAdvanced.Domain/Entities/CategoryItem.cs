using CatalogServiceNetAdvanced.Domain.Events.CategoriesEvents;

namespace CatalogServiceNetAdvanced.Domain.Entities
{
    public class CategoryItem : BaseEntity
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int ParentId { get; set; }

        private bool _done;
        public bool Done
        {
            get => _done;
            set
            {
                if (value && !_done)
                {
                    AddDomainEvent(new CategoryItemCompletedEvent(this));
                }

                _done = value;
            }
        }
    }
}