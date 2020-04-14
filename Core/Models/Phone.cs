using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.BaseTypes;
using Core.Enums;


namespace Core.Models
{
    public class Phone : TrackableEntity
    {
       
        [Required]
        [Display(Name = "Phone Number", Prompt = "Phone Number")]
        public string Number { get; set; }
        public string Ext { get; set; }

        public PhoneTypeEnum PhoneType { get; set; }
        public ICollection<ContactPhone> ContactPhoneNumbers { get; set; } = new List<ContactPhone>();
    }
}