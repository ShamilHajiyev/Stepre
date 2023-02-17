using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.Areas.Admin.Models.CreateModels;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.Areas.Admin.Controllers
{
    public class PaymentController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public PaymentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var payments = _dbContext.SupportedPayments.ToList();
            return View(payments);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var payment = _dbContext.SupportedPayments.SingleOrDefault(x => x.Id == id);

            if (payment == null)
                return NotFound();

            return View(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var supportedPayment = await _dbContext.SupportedPayments.FindAsync(id);

            if (supportedPayment == null) return NotFound();

            _dbContext.SupportedPayments.Remove(supportedPayment);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupportedPaymentCreateModel payment)
        {
            if (!ModelState.IsValid)
                return View();

            var paymentEntity = new SupportedPayment
            {
                Name = payment.Name,
                ImgUrl = payment.ImageUrl
            };

            await _dbContext.SupportedPayments.AddAsync(paymentEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
