using System;
using QLESSTransport.Models;

namespace API.QLESSTransport.Models.DTO
{
    public class TransportCardDTO : TransportCard
    {
        public DateTime? ExpirationDate {
            get => LastUsedDate.HasValue ? LastUsedDate.Value.AddYears(5) : (DateTime?)null;
        }
        public bool IsValid
        {
            get => LastUsedDate.HasValue ? LastUsedDate.Value.AddYears(5) == new DateTime() : true;
        }
    }
}