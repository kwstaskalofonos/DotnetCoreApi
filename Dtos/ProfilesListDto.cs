using System;

namespace CustomServer.Dtos
{
    public class ProfilesListDto
    {
        public string FirstName {get; set;}
        public string SurName {get; set;}
        public DateTime DateOfBirth {get; set;}
        public string Gender {get; set;}
        public int Age {get; set;}
        public string City {get; set;}
        public string PostalCode {get; set;}
        public string PhoneNumer {get; set;}
        public PhotoListDto ProfilePhoto {get; set;}
    }
}