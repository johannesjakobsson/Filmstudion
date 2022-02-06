using Filmstudion.Resources;

namespace Filmstudion.Models
{
    public interface IRegisterUserRepository
    {
        void Register(UserRegister model);
        public User GetUser(string userName);
    }
}