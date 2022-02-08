using Filmstudion.Resources;

namespace Filmstudion.Models
{
    public interface IUserRepository
    {
        void Register(UserRegister model);
        public User GetUser(string userName);
        public User GetUserWithoutException(string userName);
        public AuthenticateResponseResource Authenticate(UserAuthenticateResource model);
    }
}