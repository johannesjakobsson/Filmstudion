using System.Collections.Generic;
using System.Text.Json.Serialization;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class FilmResponseResource : IFilm
    {
        public int FilmId { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        [JsonIgnore]
        public List<FilmCopy> FilmCopies { get; set; }
    }
}