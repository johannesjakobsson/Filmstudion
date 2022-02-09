using System.Collections.Generic;
using Filmstudion.Resources;

namespace Filmstudion.Models
{
    public interface IFilmStudioRepository
    {
        public IEnumerable<FilmStudio> AllFilmStudios();
        FilmStudio Register(RegisterFilmStudioResource model);
        public FilmStudio GetFilmStudioById(int id);
        public void RentAFilm(FilmStudio studio, FilmCopy filmCopy);
    }
}