using Filmstudion.Models.Interfaces;

namespace Filmstudion.Models.FilmStudio
{
    public class FilmStudio : IFilmStudio
    {
        public int FilmStudioId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
    }
}