namespace Filmstudion.Models.Interfaces
{
    public interface IFilmStudio
    {
        public int FilmStudioId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
    }
}