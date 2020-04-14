using Core.BaseTypes;

namespace Core.Models
{
    public class ContactPhone : TrackableJoinEntity
    {
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}