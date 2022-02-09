using System.Collections.Generic;
using System.Text.Json.Serialization;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class EditFilmCopiesResource : IFilm
    {
        
        public int NumberOfCopies { get; set; }
        [JsonIgnore]
        public int FilmId { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        public int ReleaseYear { get; set; }
        [JsonIgnore]
        public string Country { get; set; }
        [JsonIgnore]
        public string Director { get; set; }
        
        [JsonIgnore]
        public IEnumerable<FilmCopy> FilmCopies { get; set; }
    }
}