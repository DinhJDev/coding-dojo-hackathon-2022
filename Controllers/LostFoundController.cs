using Hackathon.Core;
using Hackathon.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hackathon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LostFoundController : ControllerBase
    {
        private readonly LostFoundService _LostFound;

        public LostFoundController(LostFoundService LostFound)
        {
            _LostFound = LostFound;
        }
        [HttpGet(Name = "GetLostFound")]
        public LostFound GetLostFound(int id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            return _LostFound.GetOne(id);
        }
        [HttpPost(Name = "MarkLostFound")]
        public void MarkLostFound(LostFound newT)
        {
            _LostFound.Create(newT);

        }
    }
}
