using CatalogServiceNetAdvanced.Application.CategoryItems.Commands.CreateCategoryItem;
using CatalogServiceNetAdvanced.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CatalogServiceNetAdvanced.Application.IntegrationTests.CatalogItems.Commands
{
    using static Testing;
    public class CreateCategoryItemTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldCreateCartItem()
        {
            var command = new CreateCategoryItemCommand
            {
                Name = "TestName",
                Image = "https://",
                ParentId = 2
            };

            var itemId = await SendAsync(command);

            var item = await FindAsync<CategoryItem>(itemId);

            item.Should().NotBeNull();
        }
    }
}