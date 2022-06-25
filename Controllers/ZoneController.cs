using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Hackathon.Dal;
using Hackathon.Core;


namespace hackathon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZoneController : ControllerBase
    {
        private readonly ZoneService _hotZone;

        public ZoneController(ZoneService hotZone)
        {
            _hotZone = hotZone;
        }
        [HttpGet(Name = "GetZone")]
        public HotZone GetZone(int id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            return _hotZone.GetOne(id);
        }
        [HttpPost(Name = "MarkZone")]
        public void MarkZone(HotZone newT)
        {
            _hotZone.Create(newT);
             
        }
    }
}
