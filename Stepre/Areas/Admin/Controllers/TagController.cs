using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.Areas.Admin.Models.CreateModels;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.Areas.Admin.Controllers
{
    public class TagController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public TagController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var tags = _dbContext.Tags.Include(x => x.Blogs).ToList();
            return View(tags);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var tag = _dbContext.Tags.Include(x => x.Blogs).SingleOrDefault(x => x.Id == id);

            if (tag == null)
                return NotFound();

            return View(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tag = await _dbContext.Tags.FindAsync(id);

            if (tag == null) return NotFound();

            _dbContext.Tags.Remove(tag);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagCreateModel tag)
        {
            if (!ModelState.IsValid)
                return View();

            var tagEntity = new Tag
            {
                Name = tag.Name
            };

            await _dbContext.Tags.AddAsync(tagEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
