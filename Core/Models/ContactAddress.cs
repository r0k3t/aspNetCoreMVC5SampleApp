using Core.BaseTypes;

namespace Core.Models
{
    public class ContactAddress : TrackableJoinEntity
    {
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}