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
            CreateMap<User, UserResponseResource>().ForMember(x => x.UserId, ex => ex.MapFrom(i => i.Id));
            CreateMap<User, AuthenticateResponseResource>().ForMember(x => x.UserId, ex => ex.MapFrom(i => i.Id));
            CreateMap<CreateFilmResource, Film>();
            CreateMap<FilmStudio, FilmStudiosResponseResource>();
            CreateMap<Film, FilmResponseResource>();
            CreateMap<EditFilmResource, Film>().ReverseMap();
            CreateMap<Film, EditFilmResponseResource>();
        }
    }
}