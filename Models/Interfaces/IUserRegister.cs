namespace Filmstudion.Models
{
    public interface IUserRegister
    {
      public string UserName { get; set; }
      public string Password { get; set; } 
      public bool IsAdmin { get; set; }
    }
}