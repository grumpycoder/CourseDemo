using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseDemo.Data;
using CourseDemo.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseDemo.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly CourseContext _context;

        public CoursesController(CourseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Get()
        {
            var dto = await _context.Courses.Take(10).ToListAsync();
            return Ok(dto);
        }
    }
}