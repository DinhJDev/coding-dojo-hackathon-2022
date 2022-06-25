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
        //[HttpGet(Name = "/GetAllZones")]
        //public List<HotZone> GetAllZones()
        //{
        //    return _hotZone.GetAll();
        //}
        [HttpPost(Name = "MarkZone")]
        public void MarkZone(HotZone newT)
        {
            _zoneService.Create(newT);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todoItem = await _context.HotZones.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.HotZones.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
