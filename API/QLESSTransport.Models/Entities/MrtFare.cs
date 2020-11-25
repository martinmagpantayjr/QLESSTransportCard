using API.QLESSTransport.Models.Enums;

namespace API.QLESSTransport.Models.Entities
{
    public class MrtFare
    {
        public int Id { get; set; }
        public int Fare { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public MRTLineTypeEnum Line { get; set; }
    }
}