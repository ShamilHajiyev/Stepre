using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;
using Stepre.Models.CRUDModels;
using Stepre.Models.Entities;
using Stepre.Models.ViewModels;

namespace Stepre.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var tags = _dbContext.Tags.ToList();

            var contactViewModel = new ContactViewModel
            {
                Tags = tags
            };

            return View(contactViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MessageCreateModel message)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var messageEntity = new Message
            {
                Name = message.Name,
                Email = message.Email,
                Subject = message.Subject,
                Content = message.Content
            };

            await _dbContext.Messages.AddAsync(messageEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
