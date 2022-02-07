namespace Filmstudion.Models
{
    public interface IFilmCopy
    {
    public int FilmCopyId { get; set; }
    public int FilmId { get; set; }
    public bool RentedOut { get; set; }
    public int FilmStudioId { get; set; }
    }
}