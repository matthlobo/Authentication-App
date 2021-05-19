using System;
using System.Collections.Generic;
using System.Text;

namespace AuthApp.Service.Requests
{
    public class UserRequest
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
    }
}
