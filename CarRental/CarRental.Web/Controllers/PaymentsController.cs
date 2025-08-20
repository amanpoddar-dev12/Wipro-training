using CarRental.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    [Authorize(Roles = "Staff,Admin")]
    public class PaymentsController : Controller
    {
        private readonly ICarLeaseService _svc;
        public PaymentsController(ICarLeaseService svc) { _svc = svc; }

        public IActionResult Record(int leaseId) => View(model: leaseId);

        [HttpPost]
        public async Task<IActionResult> Record(int leaseId, decimal amount)
        {
            await _svc.RecordPayment(leaseId, amount);
            return RedirectToAction("Details", "Leases", new { id = leaseId });
        }

        public async Task<IActionResult> Revenue()
        {
            var total = await _svc.TotalRevenue();
            return View(model: total);
        }
    }
}
