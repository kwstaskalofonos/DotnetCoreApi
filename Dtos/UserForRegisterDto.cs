using System.ComponentModel.DataAnnotations;

namespace CustomServer.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [EmailAddress]
        public string email {get; set;}
        [Required]
        [StringLength(30,MinimumLength=8)]
        public string password {get; set;}
        [Required]
        [Compare(nameof(password),ErrorMessage="password mismatch")]
        [StringLength(30,MinimumLength=8)]
        public string passwordConfirm {get; set;}
    }
}