namespace Filmstudion.Models
{
    interface IRegisterFilmStudio
    {
        public string FilmStudioCity { get; set; }
        public string FilmStudioName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}