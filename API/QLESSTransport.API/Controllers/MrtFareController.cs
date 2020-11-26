using System.Collections.Generic;
using System.Threading.Tasks;
using API.QLESSTransport.BL.MrtFareService;
using API.QLESSTransport.Models.Entities;
using API.QLESSTransport.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace API.QLESSTransport.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MrtFareController : ControllerBase
    {
        private readonly IMrtFareService _service;
        public MrtFareController(IMrtFareService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetMrtLocations(MRTLineTypeEnum mrtLine)
        {
            return await _service.GetMrtLocations(mrtLine);
        }

        [HttpGet]
        public async Task<MrtFare> GetMrtFareByLocation(string fromLocation, string toLocation)
        {
            return await _service.GetMrtFareByLocation(fromLocation, toLocation);
        }
    }
}