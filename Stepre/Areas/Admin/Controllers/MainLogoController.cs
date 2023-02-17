using Microsoft.AspNetCore.Mvc;
using Stepre.DAL;

namespace Stepre.Areas.Admin.Controllers
{
    public class MainLogoController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public MainLogoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var mainLogo = _dbContext.MainLogos.SingleOrDefault();
            return View(mainLogo);
        }
    }
}
