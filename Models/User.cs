using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CustomServer.Models
{
    public class User: IdentityUser<long>
    {
        public string SurName {get; set;}
        public ICollection<UserRole> UserRoles {get; set;}
        public System.DateTime date {get; set;}
        public Profile Profile {get; set;}
    }
}