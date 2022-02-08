using System.Collections.Generic;
using Filmstudion.Resources;

namespace Filmstudion.Models
{
    public interface IFilmRepository
    {
        public IEnumerable<Film> AllFilms { get;}
        public Film AddFilm(CreateFilmResource model);
    }
}