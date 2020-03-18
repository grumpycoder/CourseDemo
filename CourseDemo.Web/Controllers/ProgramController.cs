using System.Threading.Tasks;
using CourseDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseDemo.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramsController : Controller
    {
        private readonly CourseContext _context;

        public ProgramsController(CourseContext context)
        {
            _context = context;
        }
        // GET
        public async Task<IActionResult> GetPrograms()
        {
            var dto = await _context.Programs.ToListAsync();
            return Ok(dto);
        }
    }
}