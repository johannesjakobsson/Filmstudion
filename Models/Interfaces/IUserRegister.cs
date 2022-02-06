namespace Filmstudion.Models
{
    public interface IUserRegister
    {
      public bool IsAdmin { get; set; }
      public string Username { get; set; }
      public string Password { get; set; }
    }
}