using System;
using System.Collections.Generic;
using System.Text;
using Core.Attributes;
using Core.BaseTypes;
using Core.Enums;
using Core.Interfaces.Types;

namespace Core.Models
{
    [ServiceReturnable]
    public class User: TrackableEntity
    {
        public UserTypeEnum UserType { get; set; }
        public Contact Contact { get; set; }
    }
}
