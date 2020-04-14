using System;

namespace Shared.Interfaces
{
    public interface ITrackable
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
