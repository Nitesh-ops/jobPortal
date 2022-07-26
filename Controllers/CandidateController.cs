using Microsoft.AspNetCore.Mvc;
using jobPortal.Data;
using jobPortal.Entities;

namespace jobPortal.Controllers
{

    [ApiController]
    [Route("api/[Controllers]")]
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
            var Candidate = await _context.candidate.SingleOrDefaultAsync(candidate => candidate.CandidateId == id);


            if (Candidate == null)
            {

                return BadRequest(string.Format("Candidate Not Found"));
            }
            return Ok(Candidate);
        }

        [HttpPost]

        public async Task<ActionResult<List<Candidate>>> addCandidate(Candidate candidate)

        {

            _context.candidate.Add(candidate);

            await _context.SaveChangesAsync();

            return Ok(await _context.candidate.ToListAsync());

        }

        [HttpPut("{id}")]

        public async Task<ActionResult<List<Candidate>>> updateCandidate(Candidate request, int id)

        {

            var can = await _context.candidate.FindAsync(id);

            if (can == null)

            {

                return BadRequest(string.Format("This id does not match any candidate. Try again"));

            }

            can.CandidateId = request.CandidateId;

            can.CandidateName = request.CandidateName;

            can.CandidateEmail = request.CandidateEmail;

            can.CandidateQualification = request.CandidateQualification;

            can.CandidateResume = request.CandidateResume;

            can.CandidateContact = request.CandidateContact;

            await _context.SaveChangesAsync();

            return Ok(await _context.candidate.ToListAsync());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Candidate>>> updateCandidate(int id)
        {
            var candidate = await _context.candidate.SingleOrDefaultAsync(candidate => candidate.CandidateId == id);
            if (candidate == null)
            {
                return BadRequest(string.Format("Candidate not found"));
            }
            _context.candidate.Remove(candidate);
            await _context.SaveChangesAsync();
            return Ok(await _context.candidate.ToListAsync());
        }
    }
}

