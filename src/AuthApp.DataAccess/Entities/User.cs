using System;
using System.ComponentModel.DataAnnotations;

namespace AuthApp.DataAccess.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }       
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}