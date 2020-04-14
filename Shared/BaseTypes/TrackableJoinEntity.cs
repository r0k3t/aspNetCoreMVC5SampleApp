using System;
using Shared.Interfaces;

namespace Shared.BaseTypes
{
    public class TrackableJoinEntity: ITrackable
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}