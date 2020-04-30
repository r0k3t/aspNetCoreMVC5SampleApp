using System;
using Core.Interfaces.Types;

namespace Core.BaseTypes
{
    public class TrackableEntity : ITrackableEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}