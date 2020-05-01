using BusinessLogic;
using Core.Interfaces;
using Core.Interfaces.BusinessLogic;
using Core.Interfaces.Services;
using Core.Models;
using Core.ServiceModels;
using Core.ViewModels;

namespace Service
{
    public class ContactService : IContactService
    {
        private IContactManager _contactManager;

        public ContactService(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        public ServiceResult AddNewContact(ContactViewModel model)
        {
            var result = _contactManager.AddNewContact(model);
            return result;
        }

        public Contact GetById(int id)
        {
            return new Contact();
        }
    }
}