using System;
using System.Collections.Generic;
using System.Text;

namespace AuthApp.Service.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
