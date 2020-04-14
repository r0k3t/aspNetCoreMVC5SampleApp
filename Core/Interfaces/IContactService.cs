using Core.Models;

namespace Core.Interfaces
{
    public interface IContactService
    {
        Contact GetById(int Id);
    }
}