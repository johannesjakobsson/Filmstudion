using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class EditFilmResponseResource : IFilm
    {
        public int FilmId { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public List<FilmCopy> FilmCopies { get; set; }
    }
}