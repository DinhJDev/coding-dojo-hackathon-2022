using Hackathon.Core;
using Hackathon.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hackathon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplyController : ControllerBase
    {
        private readonly SupplyService _supply;

        public SupplyController(SupplyService supply)
{
            _supply = supply;
        }
        [HttpGet(Name = "GetSupply")]
        public Supply GetSupply(int id)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            return _supply.GetOne(id);
        }
        [HttpPost(Name = "MarkSupply")]
        public void MarkSupply(Supply newT)
        {
            _supply.Create(newT);
             
        }
    }
}
