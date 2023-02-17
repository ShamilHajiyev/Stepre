using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.Areas.Admin.Models.CreateModels;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.Areas.Admin.Controllers
{
    public class PrivacyController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public PrivacyController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var policies = _dbContext.PrivacyPolicies.ToList();
            return View(policies);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var policy = _dbContext.PrivacyPolicies.SingleOrDefault(x => x.Id == id);

            if (policy == null)
                return NotFound();

            return View(policy);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var privacyPolicy = await _dbContext.PrivacyPolicies.FindAsync(id);

            if (privacyPolicy == null) return NotFound();

            _dbContext.PrivacyPolicies.Remove(privacyPolicy);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PrivacyPolicyCreateModel privacy)
        {
            if (!ModelState.IsValid)
                return View();

            var privacyEntity = new PrivacyPolicy
            {
                Content = privacy.Content
            };

            await _dbContext.PrivacyPolicies.AddAsync(privacyEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
