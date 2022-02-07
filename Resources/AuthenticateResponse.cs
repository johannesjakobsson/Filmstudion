using System.Text.Json.Serialization;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class AuthenticateResponse : IUser
    {
        public string Id { get; set; } // Borde det vara UserId här??
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }
    }
}