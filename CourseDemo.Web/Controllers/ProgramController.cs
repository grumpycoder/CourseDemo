using System.Threading.Tasks;
using CourseDemo.Data;
using CourseDemo.Domain.Dtos;
using CourseDemo.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

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

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetProgram(int id)
        {
            var program = await _context.Programs.FindAsync(id);
            return Ok(program);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetPrograms()
        {
            var dto = await _context.Programs.ToListAsync();
            return Ok(dto);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateProgram(int id, UpdateProgramDto dto)
        {
            var validPeriod = ValidPeriod.Create(dto.BeginYear, dto.EndYear);
            if (validPeriod.IsFailure) return BadRequest(validPeriod.Error);

            var program = _context.Programs.Find(id);

            program.UpdateDetails(dto.Name, dto.Description, dto.TraditionalForMales, dto.TraditionalForFemales);
            program.ChangeValidPeriod(validPeriod.Value);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> CreateProgram(CreateProgramDto dto)
        {
            var validPeriod = ValidPeriod.Create(dto.BeginYear, dto.EndYear);
            if (validPeriod.IsFailure) return BadRequest(validPeriod.Error);

            var cluster = await _context.Programs.SingleOrDefaultAsync(x => x.ProgramCode == dto.ProgramCode);

            if (cluster != null) return BadRequest("ProgramCode already exists");

            var newProgram = new Domain.Models.Program(dto.Name, dto.Description, dto.ProgramCode, validPeriod.Value,
                dto.TraditionalForMales, dto.TraditionalForFemales);

            _context.Programs.Attach(newProgram);

            await _context.SaveChangesAsync();

            return Ok();
        }
        
        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteProgram(int id)
        {
            var program = _context.Programs.Find(id);

            if (program == null) return NotFound();

            _context.Programs.Remove(program);

            await _context.SaveChangesAsync();

            return Ok();
        }
        
    }
}