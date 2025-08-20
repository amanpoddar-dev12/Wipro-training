using CarRental.Web.Models;
using CarRental.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    [Authorize(Roles = "Staff,Admin")]
    public class CustomersController : Controller
    {
        private readonly ICarLeaseRepository _repo;
        public CustomersController(ICarLeaseRepository repo) { _repo = repo; }

        public async Task<IActionResult> Index() => View(await _repo.ListCustomers());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Customer c)
        {
            if (!ModelState.IsValid) return View(c);
            await _repo.AddCustomer(c);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _repo.RemoveCustomer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
