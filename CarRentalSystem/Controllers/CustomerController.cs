using CarRentalSystem.DAO;
using CarRentalSystem.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICarLeaseRepository repo;

        public CustomerController()
        {
            repo = new CarLeaseRepositoryImpl();
        }

        // List customers
        public IActionResult Index()
        {
            var customers = repo.ListCustomers();
            return View(customers);
        }

        // Add customer (GET)
        public IActionResult Add()
        {
            return View();
        }

        // Add customer (POST)
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repo.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // Customer details
        public IActionResult Details(int id)
        {
            var customer = repo.FindCustomerById(id);
            return View(customer);
        }

        // Delete customer
        public IActionResult Delete(int id)
        {
            repo.RemoveCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
