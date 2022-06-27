using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Hackathon.Dal;
using Hackathon.Core;
using Microsoft.EntityFrameworkCore;


namespace Hackathon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZoneController : ControllerBase
    {
        private readonly HackathonContext _context;
        private readonly ZoneService _zoneService;

        public ZoneController(HackathonContext context, ZoneService zoneService)
        {
            _context = context;
            _zoneService = zoneService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotZone>>> GetAllZones()
        {
            return await _context.HotZones.ToListAsync();
        }

        [HttpGet("{id}")]
        public HotZone GetZones(int id)
        {
            return _zoneService.GetOne(id);
        }

        [HttpPost(Name = "MarkZone")]
        public void MarkZone(HotZone newT)
        {
            _zoneService.Create(newT);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.HotZones.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.HotZones.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
