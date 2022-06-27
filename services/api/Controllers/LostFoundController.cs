using Hackathon.Core;
using Hackathon.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LostFoundController : ControllerBase
    {
        private readonly HackathonContext _context;
        private readonly LostFoundService _lostFoundService;

        public LostFoundController(HackathonContext context, LostFoundService lostFoundService)
        {
            _context = context;
            _lostFoundService = lostFoundService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LostFound>>> GetAllZones()
        {
            return await _context.LostFounds.ToListAsync();
        }

        [HttpGet("{id}")]
        public LostFound GetZones(int id)
        {
            return _lostFoundService.GetOne(id);
        }


        [HttpPost(Name = "MarkLostFound")]
        public void MarkLostFound(LostFound newT)
        {
            _lostFoundService.Create(newT);

        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.LostFounds.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.LostFounds.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

