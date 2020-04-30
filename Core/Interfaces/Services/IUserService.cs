using Core.Models;

namespace Core.Interfaces.Services
{
    public interface IUserService<T> where T: User
    {
        T GetUser(string userName="", int id=0);
        bool UpdateUser(T user);
    }
}