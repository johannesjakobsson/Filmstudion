using AutoMapper;
using Filmstudion.Models;
using Filmstudion.Resources;

namespace Filmstudion.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<RegisterFilmStudio, User>();
            CreateMap<RegisterFilmStudio, FilmStudio>();
            CreateMap<UserRegister, User>();
            CreateMap<User, UserResponse>();
        }
    }
}