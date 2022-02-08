using System.Collections.Generic;
using AutoMapper;
using Filmstudion.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Filmstudion.Models
{
    public class FilmRepository : IFilmRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<FilmRepository> _logger;

        public FilmRepository(AppDbContext context, IMapper mapper, ILogger<FilmRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        
        public IEnumerable<Film> AllFilms { get { return _context.Films; } }

        public Film AddFilm(CreateFilmResource model)
        {
            _logger.LogInformation("Adding new film");

            var film = _mapper.Map<Film>(model);
            _context.Films.Add(film);
            _context.SaveChanges();
            return film;
        }

        
    }
}