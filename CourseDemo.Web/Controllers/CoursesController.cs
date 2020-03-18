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

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var course = await _context.Courses
                .Include(x => x.HighGrade)
                .Include(x => x.LowGrade)
                .Include(x => x.CourseType)
                .Include(x => x.CourseLevel)
                .Include(x => x.ProgramAssignments)
                .SingleOrDefaultAsync(x => x.Id == id);

            return Ok(course);
        }

        [HttpPost, Route("{courseId}/programs")]
        public async Task<IActionResult> AssignProgram(int courseId)
        {
            //, int programId, int beginYear, int? endYear
            int programId = 5;
            int beginYear = 2015;
            int? endYear = null; 
                
            var course = await _context.Courses
                .Include(x => x.HighGrade)
                .Include(x => x.LowGrade)
                .Include(x => x.CourseType)
                .Include(x => x.CourseLevel)
                .Include(x => x.ProgramAssignments)
                .SingleOrDefaultAsync(x => x.Id == courseId);

            var program = _context.Programs.Find(programId);
            course.AssignProgram(program, beginYear, endYear);

            _context.SaveChanges();

            return Ok();
        }
        
        [HttpDelete, Route("{courseId}/programs/{programId}")]
        public async Task<IActionResult> RemoveProgram(int courseId, int programId)
        {
            var course = await _context.Courses
                .Include(x => x.HighGrade)
                .Include(x => x.LowGrade)
                .Include(x => x.CourseType)
                .Include(x => x.CourseLevel)
                .Include(x => x.ProgramAssignments)
                .SingleOrDefaultAsync(x => x.Id == courseId);

            var program = _context.Programs.Find(programId);
            course.UnassignProgram(program);

            _context.SaveChanges();

            return Ok();
        }
        
    }
}