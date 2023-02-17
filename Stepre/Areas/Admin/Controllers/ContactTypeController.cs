using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.Areas.Admin.Models.CreateModels;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.Areas.Admin.Controllers
{
    public class ContactTypeController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public ContactTypeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var contactTypes = _dbContext.ContactTypes.Include(x => x.Contacts).ToList();
            return View(contactTypes);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var contactType = _dbContext.ContactTypes.Include(x => x.Contacts).SingleOrDefault(x => x.Id == id);

            if (contactType == null)
                return NotFound();

            return View(contactType);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var contactTypes = await _dbContext.ContactTypes.FindAsync(id);

            if (contactTypes == null) return NotFound();

            _dbContext.ContactTypes.Remove(contactTypes);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactTypeCreateModel contactType)
        {
            if (!ModelState.IsValid)
                return View();

            var contactTypeEntity = new ContactType
            {
                Name = contactType.Name,
            };

            await _dbContext.ContactTypes.AddAsync(contactTypeEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
