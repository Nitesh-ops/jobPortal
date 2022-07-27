global using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using jobPortal.Data;
using jobPortal.Entities;

namespace jobPortal.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        public async Task<ActionResult<List<Job>>> postJobs(List<Job> jobs)
        {
            _context.job.AddRange(jobs);
            await _context.SaveChangesAsync();
            return Ok(await _context.job.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Job>> getJobById(int id)
        {
            var findJob = await _context.job.SingleOrDefaultAsync(job => job.jobId == id);

            if (findJob == null)
            {
                return BadRequest(string.Format("Job Not Found"));
            }
            return Ok(findJob);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Job>>> deleteJobById(int id)
        {
            var findJob = await _context.job.SingleOrDefaultAsync(job => job.jobId == id);
            {
                if (findJob == null)
                {
                    return BadRequest(string.Format("Job not Found"));
                }
                _context.job.Remove(findJob);
                await _context.SaveChangesAsync();
                return Ok(await _context.job.ToListAsync());
            }
        }
        [HttpPut]
        public async Task<ActionResult<List<Job>>> updateJobById(Job requestJob)
        {
            var findJob = await _context.job.FindAsync(requestJob.jobId);
            if (findJob == null)
            {
                return BadRequest(string.Format("Job not Found"));
            }
            findJob.postDate = requestJob.postDate;
            findJob.jobTitle = requestJob.jobTitle;
            findJob.jobLocation = requestJob.jobLocation;
            findJob.jobDescription = requestJob.jobDescription;
            await _context.SaveChangesAsync();
            return Ok(await _context.job.ToListAsync());
        }

    }

}