using System.ComponentModel.DataAnnotations;

namespace ZwajApp.API.DTO
{
    public class UserForRegisterDTO
    {
        [Required]
        public string Username { get; set; } 
        [Required, StringLength(8, MinimumLength = 4,ErrorMessage="Maenf3sh el klam dah")]
        public string Password { get; set; }
    }
}