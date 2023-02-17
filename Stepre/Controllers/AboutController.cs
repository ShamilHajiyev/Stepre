using Microsoft.AspNetCore.Mvc;
using Stepre.DAL;
using Stepre.Models.ViewModels;

namespace Stepre.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AboutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var about = _dbContext.Abouts.SingleOrDefault();
            var workers = _dbContext.Workers.OrderByDescending(x => x.Salary).Take(4).ToList();

            var aboutViewModel = new AboutViewModel
            {
                About = about,
                Workers = workers
            };

            return View(aboutViewModel);
        }
    }
}
