using System.Collections.Generic;

namespace Filmstudion.Models
{
    public interface IFilmStudio
    {
        public int FilmStudioId { get; set; }
        public string FilmStudioName { get; set; }
        public string FilmStudioCity { get; set; }
        public string Email { get; set; }
        public List<FilmCopy> RentedFilmCopies { get; set; }
    }
}