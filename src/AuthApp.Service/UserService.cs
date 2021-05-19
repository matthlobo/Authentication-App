using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthApp.DataAccess;
using AuthApp.Service.Extensions;
using AuthApp.Service.Requests;
using AuthApp.Service.Responses;

namespace AuthApp.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<UserResponse> GetAll()
        {
            var users = userRepository.GetAll();
            return users.Select(x => x.ToResponse()).ToList();
        }
        public UserResponse GetByUser(UserRequest request)
        {
            var user = request.ToEntity();
            var username = user.Username;
            //var user = userRepository.GetByUser(username);
            userRepository.GetByUser(username);
            return user.ToResponse();
        }

        public UserResponse GetById(Guid id)
        {
            var user = userRepository.GetById(id);
            return user.ToResponse();
        }

        public UserResponse Add(UserRequest request)
        {
            var user = request.ToEntity();
            userRepository.Add(user);

            return user.ToResponse();
        }

        public UserResponse Edit(UserRequest request)
        {
            var user = request.ToEntity();
            userRepository.Edit(user);

            return user.ToResponse();
        }

        public void Delete(Guid id)
        {
            userRepository.Delete(id);
        }
    }
}