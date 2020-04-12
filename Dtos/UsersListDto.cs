using System.Collections.Generic;
using CustomServer.Models;

namespace CustomServer.Dtos
{
    public class UsersListDto
    {
        public long Id {get; set;}
        public string Email {get; set;}
        public ProfilesListDto Profile {get; set;}
    }
}