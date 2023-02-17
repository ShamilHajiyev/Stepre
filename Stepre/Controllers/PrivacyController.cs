using Microsoft.AspNetCore.Mvc;
using Stepre.DAL;
using Stepre.Models.ViewModels;

namespace Stepre.Controllers
{
    public class PrivacyController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PrivacyController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var privacyPolicies = _dbContext.PrivacyPolicies.ToList();

            var privacyViewModel = new PrivacyViewModel
            {
                PrivacyPolicies = privacyPolicies
            };

            return View(privacyViewModel);
        }
    }
}
