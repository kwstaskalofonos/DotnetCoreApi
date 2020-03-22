using System;

namespace CustomServer.Models
{
    public class Log
    {
        public long Id {get; set;}
        public DateTime LoggedIn {get; set;}
        public DateTime LoggedOut{get; set;}
        public User user {get; set;}
        public long UserId {get; set;}
    }
}