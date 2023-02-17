using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.Areas.Admin.Models.CreateModels;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.Areas.Admin.Controllers
{
    public class ContactController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var contacts = _dbContext.Contacts.Include(x => x.ContactType).ToList();
            return View(contacts);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var contact = _dbContext.Contacts.Include(x => x.ContactType).SingleOrDefault(x => x.Id == id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var contact = await _dbContext.Contacts.FindAsync(id);

            if (contact == null) return NotFound();

            _dbContext.Contacts.Remove(contact);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactCreateModel contact)
        {
            if (!ModelState.IsValid)
                return View();

            var contactEntity = new Contact
            {
                Name = contact.Name,
            };

            await _dbContext.Contacts.AddAsync(contactEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
