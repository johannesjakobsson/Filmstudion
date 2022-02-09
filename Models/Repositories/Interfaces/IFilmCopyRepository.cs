using System.Collections.Generic;
using Filmstudion.Resources;

namespace Filmstudion.Models
{
    public interface IFilmCopyRepository
    {
        public IEnumerable<FilmCopy> AllFilmCopys { get; }
        public IEnumerable<FilmCopy> GetFilmCopies(int filmId);
        public IEnumerable<FilmCopy> EditFilmCopies( int id, EditFilmResource model);
        public void CreateCopies(int filmId, int filmCopies);
        public void DeleteCopies(int newCopies, IEnumerable<FilmCopy> currentCopies);
        public void CreateCopies(int filmId, int newFilmCopies, int oldAmountOfCopies);
    }
}