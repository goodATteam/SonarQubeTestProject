using NUnit.Framework;

namespace CatalogServiceNetAdvanced.Application.IntegrationTests
{
    using static Testing;

    [TestFixture]
    public abstract class BaseTestFixture
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}