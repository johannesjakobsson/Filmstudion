using System.ComponentModel.DataAnnotations;

namespace Filmstudion.Models
{
    public class FilmCopy : IFilmCopy
    {
        public int FilmCopyId { get; set; }
        public int FilmId { get; set; }
        public bool RentedOut { get; set; }
        public int FilmStudioId { get; set; }
    }
}