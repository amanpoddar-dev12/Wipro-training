using CarRentalSystem.DAO;
using CarRentalSystem.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarRentalSystem.Controllers
{
    public class LeaseController : Controller
    {
        private readonly ICarLeaseRepository repo;

        public LeaseController()
        {
            repo = new CarLeaseRepositoryImpl();
        }

        // List active leases
        public IActionResult Index()
        {
            var leases = repo.ListActiveLeases();
            return View(leases);
        }

        // Create lease (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Create lease (POST)
        [HttpPost]
        public IActionResult Create(int customerID, int carID, DateTime startDate, DateTime endDate, string type)
        {
            if (ModelState.IsValid)
            {
                var lease = repo.CreateLease(customerID, carID, startDate, endDate, type);
                return RedirectToAction("Details", new { id = lease.LeaseID });
            }
            return View();
        }

        // Lease details
        public IActionResult Details(int id)
        {
            var lease = repo.ReturnCar(id);
            return View(lease);
        }

        // Lease history
        public IActionResult History()
        {
            var leases = repo.ListLeaseHistory();
            return View(leases);
        }
    }
}
