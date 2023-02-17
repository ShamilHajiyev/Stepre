using Microsoft.AspNetCore.Mvc;

namespace Stepre.Areas.Admin.Controllers
{
    
    public class DashboardController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
