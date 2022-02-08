using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class CreateFilmResource : ICreateFilm
    {
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public int NumberOfCopies { get; set; }
    }
}