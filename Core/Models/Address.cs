using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.BaseTypes;
using Core.Enums;

namespace Core.Models
{
    public class Address : TrackableEntity
    {
        

        [Required]
        [Display(Name = "Address One", Prompt = "Address One")]
        public string AddressOne { get; set; }

        [Display(Name = "Address Two", Prompt = "Address Two")]
        public string AddressTwo { get; set; }

        public AddressTypeEnum AddressType { get; set; }

        [Required]
        [Display(Name = "City", Prompt = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State", Prompt = "State")]
        public StateEnum State { get; set; }

        [Required]
        [Display(Name = "Zip", Prompt = "Zip")]
        public string Zip { get; set; }

        public ICollection<ContactAddress> ContactAddresses { get; set; } = new List<ContactAddress>();
    }
}