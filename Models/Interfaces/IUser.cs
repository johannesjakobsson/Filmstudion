namespace Filmstudion.Models
{
    public interface IUser
    {
        public string Id { get; set; } // Borde det vara UserId här??
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}