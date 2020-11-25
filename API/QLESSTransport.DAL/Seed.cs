using System.Collections.Generic;
using System.Linq;
using API.QLESSTransport.Models.Entities;
using Newtonsoft.Json;
using QLESSTransport.DAL;

namespace API.QLESSTransport.DAL
{
    public static class Seed
    {
        public static void SeedMrtFares(QLESSContext context)
        {
            if (!context.MrtFares.Any())
            {
                var mrtLineFares = new List<MrtFare>();

                var mrtLine1 = System.IO.File.ReadAllText("../QLESSTransport.DAL/MrtLine1.json");
                var mrtLine1Fares = JsonConvert.DeserializeObject<List<MrtFare>>(mrtLine1);

                var mrtLine2 = System.IO.File.ReadAllText("../QLESSTransport.DAL/MrtLine2.json");
                var mrtLine2Fares = JsonConvert.DeserializeObject<List<MrtFare>>(mrtLine2);

                mrtLineFares.AddRange(mrtLine1Fares);
                mrtLineFares.AddRange(mrtLine2Fares);

                mrtLineFares.ForEach(fare => {
                    context.MrtFares.Add(fare);
                });

                context.SaveChanges();
            }
        }
    }
}