using AutoMapper;
using Filmstudion.Models;
using Filmstudion.Resources;

namespace Filmstudion.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<RegisterFilmStudioResource, User>();
            CreateMap<RegisterFilmStudioResource, FilmStudio>();
            CreateMap<UserRegister, User>();
            CreateMap<User, UserResponseResource>();
            CreateMap<User, AuthenticateResponseResource>();
            CreateMap<CreateFilmResource, Film>();
            CreateMap<FilmStudio, FilmStudiosResponseResource>();
        }
    }
}