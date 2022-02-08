using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Filmstudion.Models
{
    public class FilmCopyRepository : IFilmCopyRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<FilmCopyRepository> _logger;

        public FilmCopyRepository(AppDbContext context, IMapper mapper, ILogger<FilmCopyRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<FilmCopy> AllFilmCopys { get { return _context.FilmCopies; } }
        public void CreateCopies(int filmId, int filmCopies)
        {
            _logger.LogInformation("Adding new film-copies");

            for( int i = 0; i < filmCopies; i++)
            {
                var filmCopy = new FilmCopy();
                filmCopy.FilmId = filmId;
                _context.FilmCopies.Add(filmCopy);
                _context.SaveChanges();
            } 
        }
        public void CreateCopies(int filmId, int newFilmCopies, int oldAmountOfCopies)
        {
            _logger.LogInformation("Adding new film-copies");

            for( int i = oldAmountOfCopies; i < newFilmCopies; i++)
            {
                var filmCopy = new FilmCopy();
                filmCopy.FilmId = filmId;
                _context.FilmCopies.Add(filmCopy);
                _context.SaveChanges();
            } 
        }

        public void DeleteCopies(int newCopies, IEnumerable<FilmCopy> currentCopies) 
        {
            // BÖR ÄVEN KONTROLLER ATT MAN INTE TAR BORT UTLÅNADE KOPIOR
            _logger.LogInformation("Deleting old film-copies");

            var counter = currentCopies.ToList().Count();
            foreach(var copy in currentCopies)
            {   
                counter--;
                _context.Remove(copy);
                if(counter <= newCopies)
                {
                    break;
                }
                
                _context.SaveChanges();
            }
        }

        public IEnumerable<FilmCopy> GetFilmCopies(int filmId)
        {
            return _context.FilmCopies.Where(fc => fc.FilmId == filmId);
        }
    }
}