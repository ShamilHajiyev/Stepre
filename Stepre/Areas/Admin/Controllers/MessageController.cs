using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;

namespace Stepre.Areas.Admin.Controllers
{
    public class MessageController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public MessageController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var messages = _dbContext.Messages.ToList();
            return View(messages);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var message = _dbContext.Messages.SingleOrDefault(x => x.Id == id);

            if (message == null)
                return NotFound();

            return View(message);
        }
    }
}
