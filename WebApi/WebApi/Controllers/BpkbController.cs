using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Pastikan namespace ini disertakan
using WebApi.Models; // Sesuaikan dengan namespace entitas Anda

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BpkbController : ControllerBase
    {
        private readonly AppDbContext _context; 

        public BpkbController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("storage-locations")]
        public async Task<IActionResult> GetStorageLocations()
        {
            var locations = await _context.ms_storage_location.ToListAsync();
            return Ok(locations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBpkb([FromBody] TrBpkb bpkb)
        {
            _context.tr_bpkbs.Add(bpkb);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBpkbById), new { id = bpkb.AgreementNumber }, bpkb);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBpkbById(int id) 
        {
            var bpkb = await _context.tr_bpkbs.FindAsync(id);

            if (bpkb == null)
                return NotFound();

            return Ok(bpkb);
        }
    }
}
