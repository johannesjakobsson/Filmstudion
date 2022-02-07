using System.Collections.Generic;

namespace Filmstudion.Models
{
    public interface IFilmCopyRepository
    {
        public void CreateCopies(int filmId, int filmCopies);
    }
}