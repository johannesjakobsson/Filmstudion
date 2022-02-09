using System.ComponentModel.DataAnnotations;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class UserRegisterResource : IUserRegister
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }        
        [Required]
        public bool IsAdmin { get; set; }
    }
}