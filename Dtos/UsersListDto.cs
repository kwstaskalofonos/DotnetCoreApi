using System.Collections.Generic;
using CustomServer.Models;

namespace CustomServer.Dtos
{
    public class UsersListDto
    {
        public string email {get; set;}
        public int userLevel {get; set;}
        public ProfilesListDto Profile {get; set;}
    }
}