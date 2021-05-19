using AuthApp.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace AuthApp.DataAccess
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        User GetByUser(string username);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Edit(User user);        
        void Delete(Guid id);
    }
}
