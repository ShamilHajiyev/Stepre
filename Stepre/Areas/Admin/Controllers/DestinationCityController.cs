using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.Areas.Admin.Models.CreateModels;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.Areas.Admin.Controllers
{
    public class DestinationCityController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public DestinationCityController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var cities = _dbContext.DestinationCities.Include(x => x.DestinationCountry).ToList();
            return View(cities);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var city = _dbContext.DestinationCities.Include(x => x.DestinationCountry).SingleOrDefault(x => x.Id == id);

            if (city == null)
                return NotFound();

            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var destinationCity = await _dbContext.DestinationCities.FindAsync(id);

            if (destinationCity == null) return NotFound();

            _dbContext.DestinationCities.Remove(destinationCity);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DestinationCityCreateModel city)
        {
            if (!ModelState.IsValid)
                return View();

            var cityEntity = new DestinationCity
            {
                Name = city.Name,
                DestinationCountry = new DestinationCountry
                {
                    Name = city.Name
                }
            };

            await _dbContext.DestinationCities.AddAsync(cityEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
