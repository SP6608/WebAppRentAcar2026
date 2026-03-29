using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebAppRentAcar.Data;
using WebAppRentAcar.Models;
using WebAppRentAcar.ViewModels;

namespace WebAppRentAcar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbcontext;
        public HomeController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<CarsIndexViewModels> models = await dbcontext
                .Cars
                .AsNoTracking()
                .OrderBy(c => c.Model)
                .ThenBy(c => c.Year)
                .Select(m => new CarsIndexViewModels()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    Model = m.Model,
                    Year = m.Year,
                    Description = m.Description,
                    Passengers = m.Passengers,
                    PricePerDay = m.PricePerDay
                }).ToListAsync();

            return View(models);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
