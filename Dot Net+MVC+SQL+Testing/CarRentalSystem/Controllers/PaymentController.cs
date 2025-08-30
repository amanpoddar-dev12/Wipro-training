using CarRentalSystem.DAO;
using CarRentalSystem.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ICarLeaseRepository repo;

        public PaymentController()
        {
            repo = new CarLeaseRepositoryImpl();
        }

        // Payment history for a customer
        public IActionResult Index(int customerID)
        {
            var payments = repo.GetPaymentHistory(customerID);
            return View(payments);
        }

        // Record payment (GET)
        public IActionResult Record(int leaseID)
        {
            ViewBag.LeaseID = leaseID;
            return View();
        }

        // Record payment (POST)
        [HttpPost]
        public IActionResult Record(int leaseID, decimal amount)
        {
            var lease = repo.ReturnCar(leaseID);
            repo.RecordPayment(lease, amount);
            return RedirectToAction("Index", new { customerID = lease.CustomerID });
        }

        // Total revenue
        public IActionResult Revenue()
        {
            var total = repo.GetTotalRevenue();
            ViewBag.TotalRevenue = total;
            return View();
        }
    }
}
