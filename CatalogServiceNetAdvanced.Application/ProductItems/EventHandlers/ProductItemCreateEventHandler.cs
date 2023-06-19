using CatalogServiceNetAdvanced.Domain.Events.ProductsEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CatalogServiceNetAdvanced.Application.ProductItems.EventHandlers
{
    public class ProductItemCreatedEventHandler : INotificationHandler<ProductItemCreatedEvent>
    {
        private readonly ILogger<ProductItemCreatedEventHandler> _logger;

        public ProductItemCreatedEventHandler(ILogger<ProductItemCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductItemCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CatalogServiceNetAdvanced Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}