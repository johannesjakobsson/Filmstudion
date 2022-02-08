using System.Collections.Generic;

namespace Filmstudion.Models
{
    public interface IFilmCopyRepository
    {
        public IEnumerable<FilmCopy> AllFilmCopys { get; }
        public IEnumerable<FilmCopy> GetFilmCopies(int filmId);
        public void CreateCopies(int filmId, int filmCopies);
        public void DeleteCopies(int newCopies, IEnumerable<FilmCopy> currentCopies);
        public void CreateCopies(int filmId, int newFilmCopies, int oldAmountOfCopies);
    }
}