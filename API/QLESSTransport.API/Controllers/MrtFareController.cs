using API.QLESSTransport.BL.MrtFareService;
using Microsoft.AspNetCore.Mvc;

namespace API.QLESSTransport.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MrtFareController : ControllerBase
    {
        private readonly IMrtFareService _service;
        public MrtFareController(IMrtFareService service)
        {
            _service = service;
        }
    }
}