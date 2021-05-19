using System;
using AuthApp.Service.Responses;
using AuthApp.Service.Requests;
using System.Collections.Generic;

namespace AuthApp.Service
{
    public interface IUserService
    {
        UserResponse GetById(Guid id);
        UserResponse GetByUser(UserRequest request);
        IEnumerable<UserResponse> GetAll();
        UserResponse Add(UserRequest request);
        UserResponse Edit(UserRequest request);
        void Delete(Guid id);
    }
}
