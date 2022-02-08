using System.Collections.Generic;
using System.Text.Json.Serialization;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class GetAllFilmStudiosResponseResource : IFilmStudio
    {
        public int FilmStudioId { get; set; }
        public string FilmStudioName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string FilmStudioCity { get; set; }
        [JsonIgnore]
        public List<FilmCopy> RentedFilmCopies { get; set; }
    }
}
