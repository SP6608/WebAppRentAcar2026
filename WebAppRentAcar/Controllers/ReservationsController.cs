using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAppRentAcar.Data;
using WebAppRentAcar.Models;
using WebAppRentAcar.ViewModels;

namespace WebAppRentAcar.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext dbcontext;

        public ReservationsController(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IQueryable<Reservation> query = dbcontext.Reservations
                .AsNoTracking()
                .Include(r => r.Car)
                .Include(r => r.User);

            if (!User.IsInRole("Admin"))
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }

                query = query.Where(r => r.UserId == userId);
            }

            var reservations = await query
                .OrderByDescending(r => r.StartDate)
                .ToListAsync();

            return View(reservations);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int carId)
        {
            bool carExists = await dbcontext.Cars.AnyAsync(c => c.Id == carId);

            if (!carExists)
            {
                return NotFound();
            }

            var model = new ReservationCreateViewModel
            {
                CarId = carId,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1)
            };

            await PopulateCarsAsync(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationCreateViewModel model)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            bool carExists = await dbcontext.Cars.AnyAsync(c => c.Id == model.CarId);

            if (!carExists)
            {
                ModelState.AddModelError(nameof(model.CarId), "Selected car does not exist.");
            }

            if (model.StartDate == default || model.EndDate == default)
            {
                ModelState.AddModelError(string.Empty, "Please select valid reservation dates.");
            }

            if (model.StartDate.Date < DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.StartDate), "Start date cannot be in the past.");
            }

            if (model.EndDate < model.StartDate)
            {
                ModelState.AddModelError(nameof(model.EndDate), "End date cannot be before start date.");
            }

            bool isTaken = await dbcontext.Reservations.AnyAsync(r =>
                r.CarId == model.CarId &&
                model.StartDate <= r.EndDate &&
                model.EndDate >= r.StartDate);

            if (isTaken)
            {
                ModelState.AddModelError(string.Empty, "This car is already reserved for the selected period.");
            }

            if (!ModelState.IsValid)
            {
                await PopulateCarsAsync(model);
                return View(model);
            }

            var reservation = new Reservation
            {
                CarId = model.CarId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                UserId = userId,
                IsApproved = false
            };

            await dbcontext.Reservations.AddAsync(reservation);
            await dbcontext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var reservation = await dbcontext.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            reservation.IsApproved = true;

            await dbcontext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var reservation = await dbcontext.Reservations
                .AsNoTracking()
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            bool isAdmin = User.IsInRole("Admin");

            if (!isAdmin && reservation.UserId != userId)
            {
                return Forbid();
            }

            if (!isAdmin && reservation.IsApproved)
            {
                return Forbid();
            }

            var model = new ReservationDeleteViewModel
            {
                Id = reservation.Id,
                CarId = reservation.CarId,
                CarName = $"{reservation.Car.Brand} {reservation.Car.Model}",
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate,
                IsApproved = reservation.IsApproved
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ReservationDeleteViewModel model)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var reservation = await dbcontext.Reservations.FindAsync(model.Id);

            if (reservation == null)
            {
                return NotFound();
            }

            bool isAdmin = User.IsInRole("Admin");

            if (!isAdmin && reservation.UserId != userId)
            {
                return Forbid();
            }

            if (!isAdmin && reservation.IsApproved)
            {
                return Forbid();
            }

            dbcontext.Reservations.Remove(reservation);
            await dbcontext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateCarsAsync(ReservationCreateViewModel model)
        {
            model.Cars = await dbcontext.Cars
                .AsNoTracking()
                .OrderBy(c => c.Brand)
                .ThenBy(c => c.Model)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.Brand} {c.Model}"
                })
                .ToListAsync();
        }
    }
}