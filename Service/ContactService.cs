using Core.Interfaces;
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