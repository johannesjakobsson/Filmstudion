using System.ComponentModel.DataAnnotations;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class RegisterFilmStudioResource : IRegisterFilmStudio
    {
        [Required]
        public string FilmStudioCity { get; set; }
        [Required]
        public string FilmStudioName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }

    }
}