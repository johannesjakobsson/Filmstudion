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

        public IEnumerable<FilmCopy> AllFilmCopys { get { return _context.FilmCopys; } }
        public void CreateCopies(int filmId, int filmCopies)
        {
            _logger.LogInformation("Adding new film-copies");

            for( int i = 0; i < filmCopies; i++)
            {
                var filmCopy = new FilmCopy();
                filmCopy.FilmId = filmId;
                _context.FilmCopys.Add(filmCopy);
                _context.SaveChangesAsync();
            }
            
        }
    }
}