using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stepre.Areas.Admin.Models.CreateModels;
using Stepre.DAL;
using Stepre.Models.Entities;

namespace Stepre.Areas.Admin.Controllers
{
    public class DestinationCountryController : BaseAdminController
    {
        private readonly AppDbContext _dbContext;

        public DestinationCountryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var countries = _dbContext.DestinationCountries.Include(x => x.DestinationCities).ToList();
            return View(countries);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var country = _dbContext.DestinationCountries.Include(x => x.DestinationCities).SingleOrDefault(x => x.Id == id);

            if (country == null)
                return NotFound();

            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var destinationCountries = await _dbContext.DestinationCountries.FindAsync(id);

            if (destinationCountries == null) return NotFound();

            _dbContext.DestinationCountries.Remove(destinationCountries);

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DestinationCountryCreateModel country)
        {
            if (!ModelState.IsValid)
                return View();

            var countryEntity = new DestinationCountry
            {
                Name = country.Name
            };

            await _dbContext.DestinationCountries.AddAsync(countryEntity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
