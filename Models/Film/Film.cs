using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.Models
{
    public class Film : IFilm
    {
        [Key]
        public int FilmId { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        public int ReleaseYear { get; set; }
        public IEnumerable<FilmCopy> FilmCopies { get; set; }
    }
}