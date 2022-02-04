using Microsoft.AspNetCore.Identity;

namespace Filmstudion.Models.Interfaces
{
    public interface IUser
    {
        public int UserId { get; set; }
        public int Username { get; set; }
        public string Role { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        public int FilmStudioId { get; set; }
    }
}