using CarRental.Web.Models;
using CarRental.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    [Authorize]
    public class LeasesController : Controller
    {
        private readonly ICarLeaseService _svc;
        public LeasesController(ICarLeaseService svc) { _svc = svc; }

        // Create lease (Customer)
        [Authorize(Roles = "Customer,Staff,Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Cars = await _svc.GetAvailableCars();
            return View();
        }

        [HttpPost, Authorize(Roles = "Customer,Staff,Admin")]
        public async Task<IActionResult> Create(int customerId, int carId, DateOnly startDate, DateOnly endDate, LeaseType type)
        {
            if (endDate < startDate) ModelState.AddModelError("", "End date must be >= start date");
            if (!ModelState.IsValid)
            {
                ViewBag.Cars = await _svc.GetAvailableCars();
                return View();
            }

            var lease = await _svc.CreateLeaseForUser(customerId, carId, startDate, endDate, type);
            return RedirectToAction(nameof(Details), new { id = lease.LeaseId });
        }

        [Authorize(Roles = "Staff,Admin")]
        public async Task<IActionResult> Active()
            => View(await _svc.TotalRevenue()); // optional, show revenue on page header

        [Authorize(Roles = "Staff,Admin")]
        public async Task<IActionResult> Return(int id)
        {
            var lease = await _svc.ReturnCar(id);
            return RedirectToAction(nameof(Details), new { id = lease.LeaseId });
        }

        [Authorize(Roles = "Customer,Staff,Admin")]
        public IActionResult Details(int id) => View(model: id); // make a simple details page per your UI
    }
}
