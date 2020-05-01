using System;
using Core.Interfaces.BusinessLogic;
using Core.Models;
using Core.ServiceModels;
using Core.ViewModels;
using DataAccess;

namespace BusinessLogic
{
    public class ContactManager: IContactManager
    {
        private ApplicationDbContext _context;

        public ContactManager(ApplicationDbContext context)
        {
            this._context = context;
        }

        public ServiceResult AddNewContact(ContactViewModel model)
        {
            var result = new ServiceResult
            {
                Success = true
            };
            try
            {
                model.Contact.ContactPhoneNumbers.Add(new ContactPhone
                {
                    Phone = model.Phone,
                    Contact = model.Contact
                });
                model.Contact.ContactAddresses.Add(new ContactAddress
                {
                    Address = model.Address,
                    Contact = model.Contact
                });
                _context.Contacts.Add(model.Contact);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                result.Error = e.Message;
                result.Success = false;
            }
            return result;
        }

        public Contact GetById(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}