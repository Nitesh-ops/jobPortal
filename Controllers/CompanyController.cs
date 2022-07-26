global using Microsoft.AspNetCore.Mvc;
using jobPortal.Data;
using jobPortal.Entities;

namespace jobPortal.Controllers

{

    [ApiController]

    [Route("api/[controller]")]



    public class CompanyController : Controller

    {

        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)

        {

            _context = context;

        }

        [HttpGet]

        public async Task<ActionResult<List<Company>>> getAllCompany()

        {

            //company define in ApplicationDbContext

            return Ok(await _context.company.ToListAsync());

        }



        //Company Id

        [HttpGet("{id}")]

        public async Task<ActionResult<Company>> getCompanyId(int id)

        {

            var company = await _context.company.SingleOrDefaultAsync(company => company.companyId == id);

            if (company == null)

            {

                return BadRequest(string.Format("Company Not Found"));

            }

            return Ok(company);

        }
        //post data in the database
        [HttpPost]
        public async Task<ActionResult<List<Company>>> addCompany(Company comp)
        {
            _context.company.Add(comp);
            await _context.SaveChangesAsync();
            return Ok(await _context.company.ToListAsync());
        }

        //Update id
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Company>>> updateCompany(Company request, int id)
        {
            var comp = await _context.company.FindAsync(id);
            if (comp == null)
            {
                return BadRequest(string.Format("This id doesn't match with any company. Try again!"));
            }
            comp.companyName = request.companyName;
            comp.companyLogo = request.companyLogo;
            comp.companyDetails = request.companyDetails;
            await _context.SaveChangesAsync();
            return Ok(await _context.company.ToListAsync());
        }

        //delete id
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Company>>> deleteEmployee(int id)
        {
            var comp = await _context.company.SingleOrDefaultAsync(company => company.companyId == id);
            if (comp == null)
            {
                return BadRequest(string.Format("Company not found"));
            }
            _context.company.Remove(comp);
            await _context.SaveChangesAsync();

            return Ok(await _context.company.ToListAsync());
        }


    }
}

