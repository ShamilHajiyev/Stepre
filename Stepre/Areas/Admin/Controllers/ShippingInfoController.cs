using Microsoft.AspNetCore.Mvc;
using Stepre.DAL;

namespace Stepre.Areas.Admin.Controllers
{
    public class ShippingInfoController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public ShippingInfoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var info = _dbContext.ShippingInformations.SingleOrDefault();
            return View(info);
        }
    }
}
