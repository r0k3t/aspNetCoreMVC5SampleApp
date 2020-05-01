using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using Core.ServiceModels;
using Core.ViewModels;

namespace Core.Interfaces.BusinessLogic
{
    public interface IContactManager
    {
        ServiceResult AddNewContact(ContactViewModel model);
        Contact GetById(int Id);
    }
}
