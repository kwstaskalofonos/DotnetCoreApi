namespace CustomServer.Models
{
    public class User
    {
        public long Id {get; set;}
        public string email {get; set;}
        public byte[] passwordHash {get; set;}
        public byte[] passwordSalt {get; set;}
        public int userLevel {get; set;}
        public System.DateTime date {get; set;}
    }
}