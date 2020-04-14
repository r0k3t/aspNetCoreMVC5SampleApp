using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.BaseTypes;
using Core.Enums;


namespace Core.Models
{
    public class Contact : TrackableEntity
    {
       

        [Required]
        [Display(Name = "First Name", Prompt = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name", Prompt = "Last Name")]
        public string LastName { get; set; }

        public ContactTypeEnum ContactType { get; set; }

        public ICollection<ContactPhone> ContactPhoneNumbers { get; set; } = new List<ContactPhone>();

        public ICollection<ContactAddress> ContactAddresses { get; set; } = new List<ContactAddress>();
    }
}