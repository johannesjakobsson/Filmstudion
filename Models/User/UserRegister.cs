using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Filmstudion.Models
{
    public class UserRegister : IUserRegister
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }        
        [Required]
        public bool IsAdmin { get; set; }
    }
}