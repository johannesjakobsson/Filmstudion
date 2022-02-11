using System.Text.Json.Serialization;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class FilmStudioAuthenticateResponseResource : IUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public int FilmStudioId { get; set; }
        public FilmStudio FilmStudio { get; set; }
        public string Token { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }

    }
}