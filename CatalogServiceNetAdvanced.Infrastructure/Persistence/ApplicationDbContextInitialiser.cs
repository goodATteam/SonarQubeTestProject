using CatalogServiceNetAdvanced.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CatalogServiceNetAdvanced.Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                //if (_context.Database.IsSqlServer())
                //{
                //    await _context.Database.MigrateAsync();
                //}
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Default data
            // Seed, if necessary
            if (!_context.CategoryItems.Any())
            {
                _context.CategoryItems.Add(new CategoryItem { Name = "Cars", Image = "https://"});
                _context.CategoryItems.Add(new CategoryItem { Name = "Small cars", Image = "https://", ParentId = 1 });
                _context.CategoryItems.Add(new CategoryItem { Name = "Middle cars", Image = "https://", ParentId = 1 });
                _context.CategoryItems.Add(new CategoryItem { Name = "Giant cars", Image = "https://", ParentId = 1 });
                _context.CategoryItems.Add(new CategoryItem { Name = "Small cars v2", Image = "https://", ParentId = 2 });
                _context.CategoryItems.Add(new CategoryItem { Name = "Middle cars v2", Image = "https://", ParentId = 3 });
                _context.CategoryItems.Add(new CategoryItem { Name = "Giant cars v2", Image = "https://", ParentId = 4 });

                await _context.SaveChangesAsync();
            }

            if (!_context.ProductItems.Any())
            {
                _context.ProductItems.Add(new ProductItem 
                {                      
                    Name = "Car1", 
                    Description = "Car1 Group car",
                    Image = "https://",
                    CategoryId = 4,
                    Price = "33.4", 
                    Amount = 199 
                });
                _context.ProductItems.Add(new ProductItem
                {
                    Name = "Car2",
                    Description = "Car2 Group car",
                    Image = "https://",
                    CategoryId = 3,
                    Price = "32.4",
                    Amount = 299
                });
                _context.ProductItems.Add(new ProductItem
                {
                    Name = "Car3",
                    Description = "Car3 Group car",
                    Image = "https://",
                    CategoryId = 2,
                    Price = "26.4",
                    Amount = 499
                });
                _context.ProductItems.Add(new ProductItem
                {
                    Name = "Car4",
                    Description = "Car4 Group car",
                    Image = "https://",
                    CategoryId = 4,
                    Price = "35.4",
                    Amount = 599
                });
                _context.ProductItems.Add(new ProductItem
                {
                    Name = "Car5",
                    Description = "Car5 Group car",
                    Image = "https://",
                    CategoryId = 3,
                    Price = "39.4",
                    Amount = 699
                });
                _context.ProductItems.Add(new ProductItem
                {
                    Name = "Car6",
                    Description = "Car6 Group car",
                    Image = "https://",
                    CategoryId = 2,
                    Price = "37.4",
                    Amount = 799
                });
                _context.ProductItems.Add(new ProductItem
                {
                    Name = "Car7",
                    Description = "Car7 Group car",
                    Image = "https://",
                    CategoryId = 5,
                    Price = "38.4",
                    Amount = 999
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}