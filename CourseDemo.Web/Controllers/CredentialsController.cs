using System.Linq;
using System.Threading.Tasks;
using CourseDemo.Data;
using CourseDemo.Domain.Dtos;
using CourseDemo.Domain.Models;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace CourseDemo.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CredentialsController : Controller
    {
        private readonly CourseContext _context;

        public CredentialsController(CourseContext context)
        {
            _context = context;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetCredential(int id)
        {
            var cluster = await _context.Credentials.FindAsync(id);
            return Ok(cluster);
        }
        
        [HttpGet, Route("")]
        public async Task<IActionResult> GetCredentials()
        {
            var list = await _context.Credentials.ToListAsync();
            return Ok(list);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateCredential(int id, UpdateCredentialDto dto)
        {
            var validPeriod = ValidPeriod.Create(dto.BeginYear, dto.EndYear);
            if (validPeriod.IsFailure) return BadRequest(validPeriod.Error);
            
            var credential = _context.Credentials.Find(id);
            
            credential.UpdateDetails(dto.Name, dto.Description, dto.IsReimbursable);
            credential.ChangeValidPeriod(validPeriod.Value);

            await _context.SaveChangesAsync();
            
            return Ok();
        }
        
        [HttpPost, Route("")]
        public async Task<IActionResult> CreateCredential(CreateCredentialDto dto)
        {
            var validPeriod = ValidPeriod.Create(dto.BeginYear, dto.EndYear);
            if (validPeriod.IsFailure) return BadRequest(validPeriod.Error);
            
            var cluster = await _context.Credentials.SingleOrDefaultAsync(x => x.CredentialCode == dto.CredentialCode);

            if (cluster != null) return BadRequest("CredentialCode already exists"); 
                
            var newCluster = new Credential(dto.Name, dto.Description, dto.CredentialCode, validPeriod.Value, dto.IsReimbursable);

            _context.Credentials.Attach(newCluster);
            
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteCredential(int id)
        {
            var credential = _context.Credentials.Find(id);

            if (credential == null) return NotFound();

            _context.Credentials.Remove(credential);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}