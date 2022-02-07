using System.Collections.Generic;
using Filmstudion.Resources;

namespace Filmstudion.Models
{
    public interface IFilmStudioRepository
    {
        public IEnumerable<FilmStudio> AllFilmStudios { get; }
        void Register(RegisterFilmStudio model);
    }
}