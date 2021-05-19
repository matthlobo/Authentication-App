using AuthApp.DataAccess.Entities;
using AuthApp.Service.Requests;
using AuthApp.Service.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthApp.Service.Extensions
{
    public static class UserExtensions
    {
        public static UserResponse ToResponse(this User user)
        {
            if (user == null)
                return null;

            return new UserResponse
            {
                Id = user.Id,               
                Username = user.Username,
                Password = user.Password,
                Role = user.Role
            };
        }

        public static User ToEntity(this UserRequest user)
        {
            if (user == null)
                return null;

            return new User
            {
                Username = user.Username,
                Password = user.Password
            };
        }
    }
}

