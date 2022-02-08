using System.Collections.Generic;

namespace Filmstudion.Models
{
    public interface IFilmRepository
    {
        public IEnumerable<Film> AllFilms { get;}
        public Film AddFilm(CreateFilmResource model);
    }
}