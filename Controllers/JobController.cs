global using Microsoft.AspNetCore.Mvc;
using jobPortal.Data;
using jobPortal.Entities;

namespace jobPortal.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class JobController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Job>>> getAllJobs()
        {
            return Ok(await _context.job.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Job>>> postJobs(Job jobs)
        {
            _context.job.Add(jobs);
            await _context.SaveChangesAsync();
            return Ok(await _context.job.ToListAsync());
        }

    }

}