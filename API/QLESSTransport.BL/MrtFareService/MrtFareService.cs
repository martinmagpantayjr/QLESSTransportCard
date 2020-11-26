using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.QLESSTransport.Models.Entities;
using API.QLESSTransport.Models.Enums;
using Microsoft.EntityFrameworkCore;
using QLESSTransport.DAL;

namespace API.QLESSTransport.BL.MrtFareService
{
    public class MrtFareService : IMrtFareService
    {
        private readonly QLESSContext _context;
        public MrtFareService(QLESSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MrtFare>> GetMrtFares()
        {
            return await _context.MrtFares.ToListAsync();
        }

        public async Task<IEnumerable<MrtFare>> GetMrtFaresByLine(MRTLineTypeEnum mrtLine)
        {
            return await _context.MrtFares.Where(p => p.Line == mrtLine).ToListAsync();
        }

        public async Task<MrtFare> GetMrtFareByLocation(string fromLocation, string toLocation)
        {
            return await _context.MrtFares.Where(m => 
            (m.FromLocation.ToLower() == fromLocation.ToLower() 
                && m.ToLocation.ToLower() == toLocation.ToLower()) 
            || (m.FromLocation.ToLower() == toLocation.ToLower() 
                && m.ToLocation.ToLower() == fromLocation.ToLower()))
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateMrtFares(IEnumerable<MrtFare> faresToUpdate)
        {
            var mrtFareIds = faresToUpdate.Select(s => s.Id).ToList();

            var mrtFares = await _context.MrtFares.Where(m => mrtFareIds.Contains(m.Id)).ToListAsync();

            mrtFares.ForEach(mrtFare => {
                var fare = faresToUpdate.FirstOrDefault(f => f.Id == mrtFare.Id)?.Fare;

                mrtFare.Fare = fare ?? mrtFare.Fare;
            });

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<string>> GetMrtLocations(MRTLineTypeEnum mrtLine)
        {
            var mrt1Locations = await _context.MrtFares.Where(m => m.Line == mrtLine)
                                                  .Select(s => s.FromLocation)
                                                  .Distinct()
                                                  .OrderBy(o => o)
                                                  .ToListAsync();

            return mrt1Locations;
        }
    }
}