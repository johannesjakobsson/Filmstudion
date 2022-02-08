using System.Text.Json.Serialization;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class AuthenticateResponseResource : IUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string FilmStudioId { get; set; }
        [JsonIgnore]
        public FilmStudio FilmStudio { get; set; }
    }
}