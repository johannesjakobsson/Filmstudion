using System.ComponentModel.DataAnnotations;
using Filmstudion.Models;

namespace Filmstudion.Resources
{
    public class CreateFilmResource : ICreateFilm
    {
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
    }
}