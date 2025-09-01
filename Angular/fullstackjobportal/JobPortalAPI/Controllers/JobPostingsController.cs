using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JobPortalAPI.Data;
using JobPortalAPI.Models;

namespace JobPortalAPI.Controllers
{
    [ApiController]
    [Route("api/jobpostings")]
    public class JobPostingsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public JobPostingsController(AppDbContext context) => _context = context;

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetJobs() => Ok(_context.JobPostings.ToList());

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddJob(JobPosting job)
        {
            _context.JobPostings.Add(job);
            _context.SaveChanges();
            return Ok(job);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateJob(int id, JobPosting updatedJob)
        {
            var job = _context.JobPostings.Find(id);
            if (job == null) return NotFound();
            job.Title = updatedJob.Title;
            job.Description = updatedJob.Description;
            job.Company = updatedJob.Company;
            _context.SaveChanges();
            return Ok(job);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteJob(int id)
        {
            var job = _context.JobPostings.Find(id);
            if (job == null) return NotFound();
            _context.JobPostings.Remove(job);
            _context.SaveChanges();
            return Ok();
        }
    }
}
