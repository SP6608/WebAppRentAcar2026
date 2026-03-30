using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppRentAcar.Data;

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
            var cars = await dbcontext.Cars
                .AsNoTracking()
                .ToListAsync();

            return View(cars);
        }
    }
}