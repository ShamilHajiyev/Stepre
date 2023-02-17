using Microsoft.AspNetCore.Mvc;
using Stepre.DAL;

namespace Stepre.Areas.Admin.Controllers
{
    public class FSVController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public FSVController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var fsv = _dbContext.FreeShippingValues.SingleOrDefault();
            return View(fsv);
        }
    }
}
