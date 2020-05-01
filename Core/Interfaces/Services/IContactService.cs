using Core.Models;
using Core.ServiceModels;
using Core.ViewModels;

namespace Core.Interfaces.Services
{
    public interface IContactService
    {
        ServiceResult AddNewContact(ContactViewModel model);
        Contact GetById(int Id);
    }
}