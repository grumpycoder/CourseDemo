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
    public class ClustersController : Controller
    {
        private readonly CourseContext _context;

        public ClustersController(CourseContext context)
        {
            _context = context;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetCluster(int id)
        {
            var cluster = await _context.Clusters.FindAsync(id);
            return Ok(cluster);
        }
        
        [HttpGet, Route("")]
        public async Task<IActionResult> GetClusters()
        {
            var list = await _context.Clusters.ToListAsync();
            return Ok(list);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateCluster(int id, UpdateClusterDto dto)
        {
            var validPeriod = ValidPeriod.Create(dto.BeginYear, dto.EndYear);
            if (validPeriod.IsFailure) return BadRequest(validPeriod.Error);
            
            var cluster = _context.Clusters.Find(id);
            
            cluster.UpdateDetails(dto.Name, dto.Description);
            cluster.ChangeValidPeriod(validPeriod.Value);

            await _context.SaveChangesAsync();
            
            return Ok();
        }
        
        [HttpPost, Route("")]
        public async Task<IActionResult> CreateCluster(int id, CreateClusterDto dto)
        {
            var validPeriod = ValidPeriod.Create(dto.BeginYear, dto.EndYear);
            if (validPeriod.IsFailure) return BadRequest(validPeriod.Error);
            
            var cluster = await _context.Clusters.SingleOrDefaultAsync(x => x.ClusterCode == dto.ClusterCode);

            if (cluster != null) return BadRequest("ClusterCode already exists"); 
                
            var newCluster = new Cluster(dto.Name, dto.Description, dto.ClusterCode, validPeriod.Value);

            _context.Clusters.Attach(newCluster);
            
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteCluster(int id)
        {
            var cluster = _context.Clusters.Find(id);

            if (cluster == null) return NotFound();

            _context.Clusters.Remove(cluster);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}