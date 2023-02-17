using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.Areas.Admin.Models.CreateModels;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Products.Include(x => x.Category).ToList();
            return View(products);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = _dbContext.Products.Include(x => x.Category).SingleOrDefault(x => x.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var product = await _dbContext.Products.FindAsync(id);

            if (product == null) return NotFound();

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateModel product)
        {
            if (!ModelState.IsValid)
                return View();

            var productEntity = new Product
            {
                Name = product.Name,
                PrimaryImageUrl = product.PrimaryImgUrl,
                SecondaryImageUrl = product.SecondaryImgUrl,
                Price = product.Price,
                Count = product.Count,
                Details = product.Details,
                Description = product.Description,
                Category = new Category
                {
                    Name = product.Category
                }
            };

            await _dbContext.Products.AddAsync(productEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
