using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.ViewComponents
{
    public class SocialMediaViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public SocialMediaViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SocialMedia> socialMedias = await _dbcontext.SocialMedias.ToListAsync();
            return View(socialMedias);
        }
    }
}
