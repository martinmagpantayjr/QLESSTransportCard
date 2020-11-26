using System.Collections.Generic;
using System.Threading.Tasks;
using API.QLESSTransport.BL.TransportCardService;
using API.QLESSTransport.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using QLESSTransport.Models;

namespace API.QLESSTransport.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransportCardController : ControllerBase
    {
        private readonly ITransportCardService _service;
        public TransportCardController(ITransportCardService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<TransportCard>> GetTransportCards()
        {
            return await _service.GetTransportCards();
        }

        [HttpPost]
        public async Task<double> AddLoad(int id, int load)
        {
            return await _service.AddLoad(id, load);
        }

        [HttpGet]
        public async Task<TransportCard> GetTransportCardById(int id)
        {
            return await _service.GetTransportCardById(id);
        }

        [HttpPost]
        public async Task<int> PurchaseTransportCard(int load)
        {
            return await _service.PurchaseTransportCard(load);
        }

        [HttpPost]
        public async Task<bool> RegisterTransportCard(int id, DiscountRegistrationTypeEnum discountType, string discountId)
        {
            return await _service.RegisterTransportCard(id, discountType, discountId);
        }

        [HttpPost]
        public async Task<double> PayFare(int id, string fromLocation, string toLocation)
        {
            return await _service.PayFare(id, fromLocation, toLocation);
        }

        [HttpGet]
        public async Task<double> GetCardBalance(int id)
        {
            return await _service.GetCardBalance(id);
        }
    }
}