using Hackathon.Core;
using Hackathon.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackerController : ControllerBase
    {
        private readonly HackathonContext _context;
        private readonly ZoneService _zoneService;
        private readonly SupplyService _supplyService;
        private readonly LostFoundService _lostFoundService;

        public TrackerController(HackathonContext context, ZoneService zoneService, SupplyService supplyService, LostFoundService lostFoundService)
        {
            _context = context;
            _zoneService = zoneService;
            _supplyService = supplyService;
            _lostFoundService = lostFoundService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotZone>>> GetAllZones()
        {
            return await _context.HotZones.ToListAsync();
        }

        [HttpGet("{id}")]
        public HotZone GetZone(int id)
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
    }
}
