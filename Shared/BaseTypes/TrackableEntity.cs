using System;
using Shared.Interfaces;

namespace Shared.BaseTypes
{
    public class TrackableEntity : ITrackable, ITrackableEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}