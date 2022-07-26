using jobPortal.Data;

namespace jobPortal.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class JobController:Controller
    {
        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext context)

        {

           _context=context;

        }

    }

}