using AuthApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthApp.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataAccessDbContext context;
        
        public UserRepository(IDataAccessDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return context.Users.Find(id);
        }
        public User GetByUser(string username)
        {
            return context.Users.Find(username);
        }

        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
              
        public void Edit(User source)
        {
            var user = GetById(source.Id);

            if (user == null)
                throw new ArgumentException($"The user with id {user.Id} wasn't found");

            user.Username = source.Username;
            user.Password = source.Password;

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
