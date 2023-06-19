using CatalogServiceNetAdvanced.Domain.Events.ProductsEvents;

namespace CatalogServiceNetAdvanced.Domain.Entities
{
    public class ProductItem : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public string? Price { get; set; }
        public int Amount { get; set; }

        private bool _done;
        public bool Done
        {
            get => _done;
            set
            {
                if (value && !_done)
                {
                    AddDomainEvent(new ProductItemCompletedEvent(this));
                }

                _done = value;
            }
        }
    }
}