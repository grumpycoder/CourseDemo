using System;
using System.Threading.Tasks;
using CourseDemo.Data;
using CourseDemo.Domain.Dtos;
using CourseDemo.Domain.Models;
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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await _context.Courses
                .SingleOrDefaultAsync(x => x.Id == id);

            return Ok(course);
        }

        [HttpPost]
        [Route("{courseId}/programs")]
        public async Task<IActionResult> AssignProgram(int courseId, AssignProgramDto dto)
        {
            var course = await _context.Courses
                .Include(x => x.ProgramAssignments)
                .SingleOrDefaultAsync(x => x.Id == courseId);

            var program = _context.Programs.Find(dto.ProgramId);

            var validPeriod = ValidPeriod.Create(dto.BeginYear, dto.EndYear);
            if (validPeriod.IsFailure) return BadRequest(validPeriod.Error);

            course.AssignProgram(program, validPeriod.Value);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{courseId}/programs/{programId}")]
        public async Task<IActionResult> RemoveProgram(int courseId, int programId)
        {
            var course = await _context.Courses
                .Include(x => x.ProgramAssignments)
                .SingleOrDefaultAsync(x => x.Id == courseId);

            var program = _context.Programs.Find(programId);
            course.RemoveProgram(program);

            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("{courseId}")]
        public async Task<IActionResult> UpdateCourse(int courseId, UpdateCourseDto dto)
        {
            var course = await _context.Courses.FindAsync(courseId);

            course.UpdateDetails(dto.Title, dto.Description);

            var validPeriod = ValidPeriod.Create(dto.BeginYear, dto.EndYear);
            if (validPeriod.IsFailure) return BadRequest(validPeriod.Error);
            course.ChangeValidPeriod(validPeriod.Value);

            course.ChangeCreditDetails(dto.CreditRecoveryAvailable, dto.CreditAdvancementAvailable, dto.CreditUnits);

            var lowGrade = _context.Grades.Find(dto.LowGradeId);
            var highGrade = _context.Grades.Find(dto.HighGradeId);
            var result = course.ChangeGradeRange(lowGrade, highGrade);
            if (result.IsFailure) return BadRequest(result.Error);

            var courseType = _context.CourseTypes.Find(dto.CourseTypeId);
            var courseLevel = _context.CourseLevels.Find(dto.CourseLevelId);
            course.ChangeCourseType(courseType, courseLevel);

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> CreateCourse(CreateCourseDto dto)
        {
            var validPeriod = ValidPeriod.Create(dto.BeginYear, dto.EndYear);
            if (validPeriod.IsFailure) return BadRequest(validPeriod.Error);
            
            var lowGrade = _context.Grades.Find(dto.LowGradeId);
            var highGrade = _context.Grades.Find(dto.HighGradeId);
            if (lowGrade == null || highGrade == null) return BadRequest("Invalid Grade range supplied");
            
            try
            {
                var course = new Course(dto.Title, dto.Description, validPeriod.Value, lowGrade, highGrade);
                _context.Courses.Attach(course);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}