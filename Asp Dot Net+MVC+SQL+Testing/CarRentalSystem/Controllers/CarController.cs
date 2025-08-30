using CarRentalSystem.DAO;
using CarRentalSystem.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarLeaseRepository repo;

        public CarController()
        {
            repo = new CarLeaseRepositoryImpl();
        }

        // List all available cars
        public IActionResult Index()
        {
            var cars = repo.ListAvailableCars();
            return View(cars);
        }

        // Add car (GET)
        public IActionResult Add()
        {
            return View();
        }

        // Add car (POST)
        [HttpPost]
        public IActionResult Add(Car car)
        {
            if (ModelState.IsValid)
            {
                repo.AddCar(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // Car details
        public IActionResult Details(int id)
        {
            var car = repo.FindCarById(id);
            return View(car);
        }

        // Delete car
        public IActionResult Delete(int id)
        {
            repo.RemoveCar(id);
            return RedirectToAction("Index");
        }
    }
}
