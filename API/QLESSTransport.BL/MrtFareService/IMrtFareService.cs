using System.Collections.Generic;
using System.Threading.Tasks;
using API.QLESSTransport.Models.Entities;
using API.QLESSTransport.Models.Enums;

namespace API.QLESSTransport.BL.MrtFareService
{
    public interface IMrtFareService
    {
        Task<IEnumerable<MrtFare>> GetMrtFares();
        Task<MrtFare> GetMrtFareByLocation(string fromLocation, string toLocation);
        Task<IEnumerable<MrtFare>> GetMrtFaresByLine(MRTLineTypeEnum mrtLine);
        Task<bool> UpdateMrtFares(IEnumerable<MrtFare> faresToUpdate);
        Task<IEnumerable<string>> GetMrtLocations(MRTLineTypeEnum mrtLine);
    }
}