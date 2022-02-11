using System;
using System.Collections.Generic;
using System.Linq;
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

        private IFilmCopyRepository _filmCopyRepository;

        public FilmRepository(AppDbContext context, IMapper mapper, ILogger<FilmRepository> logger, IFilmCopyRepository filmCopyRepository)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _filmCopyRepository = filmCopyRepository;
        }
        
        public IEnumerable<Film> AllFilms { get { return _context.Films; } }

        public Film AddFilm(CreateFilmResource model)
        {
            _logger.LogInformation("Adding new film");

            var nameTaken = _context.Films.FirstOrDefault(f => f.Name == model.Name);
            if(nameTaken != null) throw new Exception("Film name already exists");

            var film = _mapper.Map<Film>(model);
            
            _context.Films.Add(film);
            _context.SaveChanges();

            _filmCopyRepository.CreateCopies(film.FilmId, model.NumberOfCopies);

            return film;
        }

        public Film GetFilmById(int id)
        {
            _logger.LogInformation("Get a film");

            return _context.Films.FirstOrDefault(f => f.FilmId == id);
        }

        public Film EditFilmById(int id, EditFilmResource model)
        {
            _logger.LogInformation("Edit a film");

            var oldFilm = GetFilmById(id);

            if (oldFilm == null)
            {
                throw new Exception("Film not found");
            }

            //var newFilmCopies = _filmCopyRepository.EditFilmCopies(id, model);

            var newFilm = _mapper.Map(model,oldFilm);
            newFilm.FilmId = id;
            newFilm.FilmCopies = _filmCopyRepository.GetFilmCopies(model.FilmId).ToList();
            
            _context.Films.Update(newFilm);
            _context.SaveChanges();
            return newFilm;
        }
    }
}