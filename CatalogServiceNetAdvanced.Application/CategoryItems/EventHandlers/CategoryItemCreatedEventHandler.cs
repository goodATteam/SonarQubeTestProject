using CatalogServiceNetAdvanced.Domain.Events.CategoriesEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CatalogServiceNetAdvanced.Application.CategoryItems.EventHandlers
{
    public class CategoryItemCreatedEventHandler : INotificationHandler<CategoryItemCreatedEvent>
    {
        private readonly ILogger<CategoryItemCreatedEventHandler> _logger;

        public CategoryItemCreatedEventHandler(ILogger<CategoryItemCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CategoryItemCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CatalogServiceNetAdvanced Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}