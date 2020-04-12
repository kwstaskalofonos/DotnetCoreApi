using System;

namespace CustomServer.Models
{
    public class Profile
    {
        public long Id {get; set;}
        public DateTime DateOfBirth {get; set;}
        public string Gender {get; set;}
        public string City {get; set;}
        public string PostalCode {get; set;}
        public string PhoneNumber {get; set;}
        public Photo ProfilePhoto {get; set;}
        public User User {get; set;}
        public long UserId {get; set;}
    }
}