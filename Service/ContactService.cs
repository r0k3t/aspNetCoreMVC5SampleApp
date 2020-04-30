using Core.Interfaces;
using Core.Interfaces.Services;
using Core.Models;

namespace Service
{
    public class ContactService : IContactService
    {
        public Contact GetById(int id)
        {
            return new Contact();
        }
    }
}