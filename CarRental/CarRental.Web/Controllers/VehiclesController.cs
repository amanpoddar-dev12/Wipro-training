using CarRental.Web.Models;
using CarRental.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ICarLeaseRepository _repo;
        public VehiclesController(ICarLeaseRepository repo) { _repo = repo; }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var cars = await _repo.ListAvailableCars();
            return View(cars);
        }

        [Authorize(Roles = "Admin,Staff")]
        public IActionResult Create() => View();

        [HttpPost, Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Create(Vehicle v)
        {
            if (!ModelState.IsValid) return View(v);
            await _repo.AddCar(v);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.RemoveCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
