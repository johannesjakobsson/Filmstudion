using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class UserResponse : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}