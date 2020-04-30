using Core.Models;

namespace Core.Interfaces.Services
{
    public interface IContactService
    {
        Contact GetById(int Id);
    }
}