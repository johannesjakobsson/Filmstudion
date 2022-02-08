using System.ComponentModel.DataAnnotations;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class UserAuthenticateResource : IUserAuthenticate
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}