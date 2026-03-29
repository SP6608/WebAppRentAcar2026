using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppRentAcar.Data;
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
        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await dbcontext
                .Cars
                .AsNoTracking()
                .Where(m => m.Id == id)
                .Select(m => new CarDetailsViewModel()
                {
                    Id = m.Id,
                    Brand = m.Brand,
                    Model = m.Model,
                    Description = m.Description,
                    Year = m.Year,
                    Passengers = m.Passengers,
                    PricePerDay = m.PricePerDay,
                })
                .SingleOrDefaultAsync();

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }//end Details One Model Only

    }
}
