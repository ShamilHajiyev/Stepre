using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;

namespace Stepre.ViewComponents
{
    public class MegamenuViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public MegamenuViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _dbcontext.Categories.ToListAsync();
            return View(categories);
        }
    }
}
