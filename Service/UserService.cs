using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;
using Core.Interfaces.Services;
using Core.Models;

namespace Service
{
    public class UserService: IUserService<User>
    {
        public User GetUser(string userName = "", int id = 0)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
