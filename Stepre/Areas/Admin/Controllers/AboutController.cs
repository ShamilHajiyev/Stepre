using Microsoft.AspNetCore.Mvc;
using Stepre.DAL;

namespace Stepre.Areas.Admin.Controllers
{
    public class AboutController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public AboutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var about = _dbContext.Abouts.SingleOrDefault();
            return View(about);
        }
    }
}
