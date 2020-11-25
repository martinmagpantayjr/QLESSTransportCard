using System;
using API.QLESSTransport.Models.Enums;

namespace QLESSTransport.Models
{
    public class TransportCard
    {
        public int Id { get; set; }
        public string DiscountId { get; set; } // PWD ID or Senior ID
        public DiscountRegistrationTypeEnum DiscountRegistrationType { get; set; }
        public DateTime PurchaseDate { get; set; } = new DateTime();
        public DateTime? LastUsedDate { get; set; }
        public double Load { get; set; }
        public TransportCardTypeEnum TransportCardType { get; set; }
        public int DiscountAppliedCount { get; set; }
    }
}
