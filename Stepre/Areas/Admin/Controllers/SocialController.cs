using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.Areas.Admin.Models.CreateModels;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.Areas.Admin.Controllers
{
    public class SocialController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public SocialController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var socials = _dbContext.SocialMedias.ToList();
            return View(socials);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var social = _dbContext.SocialMedias.SingleOrDefault(x => x.Id == id);

            if (social == null)
                return NotFound();

            return View(social);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var socialMedia = await _dbContext.SocialMedias.FindAsync(id);

            if (socialMedia == null) return NotFound();

            _dbContext.SocialMedias.Remove(socialMedia);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SocialMediaCreateModel social)
        {
            if (!ModelState.IsValid)
                return View();

            var socialEntity = new SocialMedia
            {
                Icon = social.Icon,
                Platform = social.Platform,
                Url = social.Url
            };

            await _dbContext.SocialMedias.AddAsync(socialEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
