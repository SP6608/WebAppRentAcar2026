using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppRentAcar.Data;
using WebAppRentAcar.Models;
using WebAppRentAcar.ViewModels;

namespace WebAppRentAcar.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext dbcontext;

        public CarsController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cars = await dbcontext.Cars
                .AsNoTracking()
                .ToListAsync();

            return View(cars);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form)
        {
            string brand = form["Brand"].ToString().Trim();
            string model = form["Model"].ToString().Trim();
            string description = form["Description"].ToString().Trim();

            bool yearOk = int.TryParse(form["Year"], out int year);
            bool passengersOk = int.TryParse(form["Passengers"], out int passengers);

            string priceText = form["PricePerDay"].ToString().Trim();
            bool priceOk =
                decimal.TryParse(priceText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal pricePerDay) ||
                decimal.TryParse(priceText, NumberStyles.Any, CultureInfo.CurrentCulture, out pricePerDay);

            if (string.IsNullOrWhiteSpace(brand))
            {
                ModelState.AddModelError("Brand", "Brand is required.");
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                ModelState.AddModelError("Model", "Model is required.");
            }

            if (!yearOk || year < 1950 || year > 2080)
            {
                ModelState.AddModelError("Year", "Year must be between 1950 and 2080.");
            }

            if (!passengersOk || passengers < 1 || passengers > 6)
            {
                ModelState.AddModelError("Passengers", "Passengers must be between 1 and 6.");
            }

            if (!priceOk || pricePerDay < 1 || pricePerDay > 500)
            {
                ModelState.AddModelError("PricePerDay", "Price per day must be between 1 and 500.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            Car car = new Car
            {
                Brand = brand,
                Model = model,
                Year = year,
                Passengers = passengers,
                Description = string.IsNullOrWhiteSpace(description) ? null : description,
                PricePerDay = pricePerDay
            };

            await dbcontext.Cars.AddAsync(car);
            await dbcontext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            CarsEditViewModel? model = await dbcontext
                .Cars
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CarsEditViewModel
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    Passengers = c.Passengers,
                    Description = c.Description,
                    PricePerDay = c.PricePerDay
                })
                .SingleOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CarsEditViewModel mode)
        {
            if (!ModelState.IsValid)
            {
                return View(mode);
            }

            Car? car = await dbcontext.Cars.FindAsync(mode.Id);

            if (car == null)
            {
                return NotFound();
            }

            car.Brand = mode.Brand;
            car.Model = mode.Model;
            car.Year = mode.Year;
            car.Passengers = mode.Passengers;
            car.Description = mode.Description;
            car.PricePerDay = mode.PricePerDay;

            await dbcontext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            CarsDeleteViewModel? model = await dbcontext.Cars
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CarsDeleteViewModel
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    Passengers = c.Passengers,
                    PricePerDay = c.PricePerDay,
                    Description = c.Description
                })
                .SingleOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CarsDeleteViewModel models)
        {
            Car? car = await dbcontext.Cars.FindAsync(models.Id);

            if (car == null)
            {
                return NotFound();
            }

            dbcontext.Cars.Remove(car);
            await dbcontext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}