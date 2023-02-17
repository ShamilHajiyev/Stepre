using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.Areas.Admin.Models.CreateModels;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var categories = _dbContext.Categories.Include(x => x.Products).ToList();
            return View(categories);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var category = _dbContext.Categories.Include(x => x.Products).SingleOrDefault(x => x.Id == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null) return NotFound();

            _dbContext.Categories.Remove(category);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateModel category)
        {
            if (!ModelState.IsValid)
                return View();

            var categoryEntity = new Category
            {
                Name = category.Name
            };

            await _dbContext.Categories.AddAsync(categoryEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
