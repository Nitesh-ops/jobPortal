using Microsoft.AspNetCore.Mvc;
using jobPortal.Data;
using jobPortal.Entities;

namespace jobPortal.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class CandidateController : Controller
    {

        private readonly ApplicationDbContext _context;
        public CandidateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Candidate>>> getAllCandidate()
        {
            return Ok(await _context.candidate.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> getAllCandidateById(int id)
        {
            var findCandidate = await _context.candidate.SingleOrDefaultAsync(candidate => candidate.candidateId == id);
            if (findCandidate == null)
            {
                return BadRequest(string.Format("Candidate Not Found"));
            }
            return Ok(findCandidate);
        }

        [HttpPost]
        public async Task<ActionResult<List<Candidate>>> addCandidate(Candidate requestCandidate)
        {
            _context.candidate.Add(requestCandidate);
            await _context.SaveChangesAsync();
            return Ok(await _context.candidate.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<Candidate>>> updateCandidate(Candidate requestCandidate)
        {
            var findCandidate = await _context.candidate.FindAsync(requestCandidate.candidateId);

            if (findCandidate == null)
            {
                return BadRequest(string.Format("This id does not match any candidate. Try again"));
            }

            findCandidate.candidateId = requestCandidate.candidateId;

            findCandidate.candidateName = requestCandidate.candidateName;

            findCandidate.candidateEmail = requestCandidate.candidateEmail;

            findCandidate.candidateQualification = requestCandidate.candidateQualification;

            findCandidate.candidateResume = requestCandidate.candidateResume;

            findCandidate.candidateContact = requestCandidate.candidateContact;

            await _context.SaveChangesAsync();
            return Ok(await _context.candidate.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Candidate>>> updateCandidate(int id)
        {
            var findCandidate = await _context.candidate.SingleOrDefaultAsync(candidate => candidate.candidateId == id);
            if (findCandidate == null)
            {
                return BadRequest(string.Format("Candidate not found"));
            }
            _context.candidate.Remove(findCandidate);
            await _context.SaveChangesAsync();
            return Ok(await _context.candidate.ToListAsync());
        }
    }
}

