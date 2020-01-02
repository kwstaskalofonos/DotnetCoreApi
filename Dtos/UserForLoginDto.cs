using System.ComponentModel.DataAnnotations;

namespace CustomServer.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        [EmailAddress]
        public string email {get; set;}
        [Required]
        public string password {get; set;}
    }
}