using System.Collections.Generic;
using Filmstudion.Resources;

namespace Filmstudion.Models
{
    public interface IFilmRepository
    {
        public IEnumerable<Film> AllFilms { get;}
        public Film AddFilm(CreateFilmResource model);
        public Film GetFilmById(int id);
        public Film EditFilmById(int id, EditFilmResource model);
    }
}