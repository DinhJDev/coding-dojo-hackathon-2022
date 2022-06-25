using Hackathon.Core;
using Hackathon.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplyController : ControllerBase
    {
        private readonly HackathonContext _context;
        private readonly SupplyService _supplyService;

        public SupplyController(HackathonContext context, SupplyService supply)
        {
            _context = context;
            _supplyService = supply;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supply>>> GetAllZones()
        {
            return await _context.Supplies.ToListAsync();
        }

        [HttpGet("{id}")]
        public Supply GetZones(int id)
        {
            return _supplyService.GetOne(id);
        }


        [HttpPost(Name = "MarkSupply")]
        public void MarkSupply(Supply newT)
        {
            _supplyService.Create(newT);

        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Supplies.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Supplies.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
