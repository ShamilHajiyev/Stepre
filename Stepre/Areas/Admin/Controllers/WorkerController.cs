using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.Areas.Admin.Models.CreateModels;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.Areas.Admin.Controllers
{
    public class WorkerController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public WorkerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var workers = _dbContext.Workers.ToList();
            return View(workers);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var worker = _dbContext.Workers.SingleOrDefault(x => x.Id == id);

            if (worker == null)
                return NotFound();

            return View(worker);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var worker = await _dbContext.Workers.FindAsync(id);

            if (worker == null) return NotFound();

            _dbContext.Workers.Remove(worker);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkerCreateModel worker)
        {
            if (!ModelState.IsValid)
                return View();

            var workerEntity = new Worker
            {
                Name = worker.Name,
                Surname = worker.Surname,
                Salary = worker.Salary,
                FacebookUrl = worker.FacebookUrl,
                TwitterUrl = worker.TwitterUrl,
                Profession = worker.Profession,
                ImgUrl = worker.ImageUrl
            };

            await _dbContext.Workers.AddAsync(workerEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
