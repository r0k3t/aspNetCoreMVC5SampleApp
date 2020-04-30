using Core.Models;

namespace Core.Interfaces.BusinessLogic
{
    public interface IUserManager<T> where T : User
    {
        bool Add(T t);
        bool Update(T t);
    }
}