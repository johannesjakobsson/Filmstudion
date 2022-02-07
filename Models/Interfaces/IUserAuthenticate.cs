using System.ComponentModel.DataAnnotations;

namespace Filmstudion.Models
{
    public interface IUserAuthenticate
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}