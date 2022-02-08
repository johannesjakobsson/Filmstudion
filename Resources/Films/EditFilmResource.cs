using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class EditFilmResource : IFilm
    {
        public int FilmId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public int NumberOfCopies { get; set; }
        [JsonIgnore]
        public IEnumerable<FilmCopy> FilmCopies { get; set; }
    }
}