using System.Collections.Generic;
using System.Threading.Tasks;
using API.QLESSTransport.Models.Enums;
using QLESSTransport.Models;

namespace API.QLESSTransport.BL.TransportCardService
{
    public interface ITransportCardService
    {
        Task<IEnumerable<TransportCard>> GetTransportCards();
        Task<TransportCard> GetTransportCardById(int id);
        Task<double> AddLoad(int id, int load);
        Task<int> PurchaseTransportCard(int load);
        Task<bool> RegisterTransportCard(int id, DiscountRegistrationTypeEnum discountType, string discountId);
        Task<double> PayFare(int id, string fromLocation, string toLocation);
        Task<double> GetCardBalance(int id);
    }
}