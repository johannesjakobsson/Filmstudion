using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Filmstudion.Models
{
    public class FilmStudio : IFilmStudio
    {
        public int FilmStudioId { get; set; }
        public string FilmStudioName { get; set; }
        public string FilmStudioCity { get; set; }
        public string Email { get; set; }
        public List<FilmCopy> RentedFilmCopies { get; set; }
    }
}