using System;

namespace CustomServer.Models
{
    public class Photo
    {
        public long Id {get; set;}
        public string Url {get; set;}
        public DateTime DateAdded {get; set;}
        public Profile Profile {get; set;}
        public long ProfileId {get; set;}
    }
}