using System.ComponentModel.DataAnnotations;

namespace ZwajApp.API.DTO
{
    public class UserForLoginDTO
    {
        public string Username { get; set; } 
        public string Password { get; set; }
    }
}