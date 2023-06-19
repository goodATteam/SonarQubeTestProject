
using CatalogServiceNetAdvanced.Domain.Events.CategoriesEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CatalogServiceNetAdvanced.Application.CategoryItems.EventHandlers
{
    public class CategoryItemCompletedEventHandler : INotificationHandler<CategoryItemCompletedEvent>
    {
        private readonly ILogger<CategoryItemCompletedEventHandler> _logger;

        public CategoryItemCompletedEventHandler(ILogger<CategoryItemCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CategoryItemCompletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CatalogServiceNetAdvanced Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}