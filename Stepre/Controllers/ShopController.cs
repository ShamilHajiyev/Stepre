using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;
using Stepre.Models.Entities;
using Stepre.Models.ViewModels;

namespace Stepre.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ShopController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categories = _dbContext.Categories.Include(x => x.Products).ToList();
            var products = _dbContext.Products.Include(x => x.Category).ToList();
            var tags = _dbContext.Tags.ToList();

            var shopViewModel = new ShopViewModel
            {
                Categories = categories,
                Products = products,
                Tags = tags
            };

            return View(shopViewModel);
        }

        public IActionResult Filter(int minPrice, int maxPrice)
        {
            var products = _dbContext.Products.Include(x => x.Category).ToList();

            var filteredProducts = products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();

            return PartialView("_FilteredProductsPartial", filteredProducts);
        }

        public IActionResult FilterByCategory(string categoryName)
        {
            var products = _dbContext.Products.Include(x => x.Category).ToList();

            var filteredProducts = products.Where(p => p.Category.Name == categoryName).ToList();

            return PartialView("_FilteredProductsByCategoryPartial", filteredProducts);
        }

        public IActionResult Sort(string sortBy)
        {
            var products = _dbContext.Products.Include(x => x.Category).ToList();

            List<Product> sortedProducts;

            switch (sortBy)
            {
                case "nameAsc":
                    sortedProducts = products.OrderBy(x => x.Name).ToList();
                    break;
                case "nameDesc":
                    sortedProducts = products.OrderByDescending(x => x.Name).ToList();
                    break;
                case "priceAsc":
                    sortedProducts = products.OrderBy(x => x.Price).ToList();
                    break;
                case "priceDesc":
                    sortedProducts = products.OrderByDescending(x => x.Price).ToList();
                    break;
                default:
                    sortedProducts = products.ToList();
                    break;
            }

            return PartialView("_SortPartial", sortedProducts);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = _dbContext.Products.Include(x => x.Category).SingleOrDefault(x => x.Id == id);

            if (id == null)
                return NotFound();

            return View(product);
        }
    }
}
