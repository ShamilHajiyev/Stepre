using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.ViewComponents
{
    public class RelatedProductViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public RelatedProductViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> products = await _dbcontext.Products.Include(x => x.Category).ToListAsync();
            return View(products);
        }
    }
}
