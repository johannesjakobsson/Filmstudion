using Filmstudion.Resources;

namespace Filmstudion.Models
{
    public interface IUserRepository
    {
        public User Register(UserRegisterResource model);
        public User GetUser(string userName);
        public User GetUserWithoutException(string userName);
        public User Authenticate(UserAuthenticateResource model);
    }
}