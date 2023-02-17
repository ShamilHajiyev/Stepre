using Microsoft.AspNetCore.Mvc;
using Stepre.DAL;

namespace Stepre.Controllers
{
    public class WishListController : Controller
    {
        private readonly AppDbContext _dbContext;

        public WishListController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
