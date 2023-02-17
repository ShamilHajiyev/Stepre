using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;

namespace Stepre.ViewComponents
{
    public class LogoViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public LogoViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var logo = await _dbcontext.MainLogos.SingleOrDefaultAsync();
            return View(logo);
        }
    }
}
