using Microsoft.AspNetCore.Mvc;
using jobPortal.Data;
using jobPortal.Entities;


namespace jobPortal.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AppliedJobController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppliedJobController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/appliedJob/{candidateId}/{jobId}/{appliedId}")]
        public async Task<ActionResult<List<AppliedJob>>> applyJob(int candidateId, int jobId, int appliedId1)
        {
            var findCandidate = await _context.candidate.SingleOrDefaultAsync(candidate => candidate.candidateId == candidateId);
            var findJob = await _context.job.SingleOrDefaultAsync(job => job.jobId == jobId);

            if (findCandidate == null || findJob == null)
            {
                return BadRequest(string.Format("Please check candidate ID or Job ID"));
            }

            AppliedJob appliedJob1 = new AppliedJob()
            {
                appliedId = appliedId1,
                candidateId = findCandidate.candidateId,
                jobId = findJob.jobId
            };
            _context.appliedJob.Add(appliedJob1);
            await _context.SaveChangesAsync();
            return Ok(await _context.appliedJob.ToListAsync());


        }

        [HttpGet]
        [Route("/appliedJob/{appliedId}")]
        public async Task<ActionResult<List<AppliedJob>>> getAllJobs(int appliedId1)
        {
            var findAppliedJob=await _context.appliedJob.SingleOrDefaultAsync(applyJob=>applyJob.appliedId==appliedId1);
            if(findAppliedJob==null)
            {
                return BadRequest(string.Format("Please check Applied ID"));
            }

            var findCandidate = await _context.candidate.SingleOrDefaultAsync(candidate => candidate.candidateId == findAppliedJob.candidateId);
            var findJob = await _context.job.SingleOrDefaultAsync(job => job.jobId == findAppliedJob.jobId);
            return Ok(await _context.appliedJob.ToListAsync());
        }


    }
}
