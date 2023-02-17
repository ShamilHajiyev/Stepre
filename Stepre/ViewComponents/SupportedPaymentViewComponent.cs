using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.ViewComponents
{
    public class SupportedPaymentViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbcontext;

        public SupportedPaymentViewComponent(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SupportedPayment> supportedPayments = await _dbcontext.SupportedPayments.ToListAsync();
            return View(supportedPayments);
        }
    }
}
