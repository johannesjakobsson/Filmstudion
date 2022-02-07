using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Filmstudion.Models
{
    public class User : IdentityUser, IFilmStudio
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public bool IsAdmin { get; set; }  
        public int FilmStudioId { get; set; }
        public string FilmStudioName { get; set; }
        public string FilmStudioCity { get; set; }
        public string ContactPerson { get; set; }
        public List<FilmCopy> RentedFilmCopies { get; set; }
    }
}