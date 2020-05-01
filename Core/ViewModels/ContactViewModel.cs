using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.ViewModels
{
    public class ContactViewModel
    {
        public Contact Contact { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
        public Note Note { get; set; }
     }
}
