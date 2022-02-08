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

            var film = _mapper.Map<Film>(model);
            
            _context.Films.Add(film);
            _context.SaveChanges();

            var savedFilm = _context.Films.FirstOrDefault(f => f.Name == model.Name);
            _filmCopyRepository.CreateCopies(savedFilm.FilmId, model.NumberOfCopies);

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

            var copiesCount = _filmCopyRepository.GetFilmCopies(id).ToList().Count();

            if(copiesCount != model.NumberOfCopies)
                {

                    if(copiesCount > model.NumberOfCopies)
                    {
                        var newCopies = model.NumberOfCopies;
                        var currentCopies = _filmCopyRepository.GetFilmCopies(id);
                        _filmCopyRepository.DeleteCopies(newCopies, currentCopies);
                    }
                    else if (copiesCount < model.NumberOfCopies)
                    {
                        _filmCopyRepository.CreateCopies(id, model.NumberOfCopies, copiesCount);
                    }
                }

            var newFilm = _mapper.Map(model,oldFilm);
            newFilm.FilmId = id;
            newFilm.FilmCopies = _filmCopyRepository.GetFilmCopies(id).ToList();
            
            _context.Films.Update(newFilm);
            _context.SaveChanges();
            return newFilm;
        }
    }
}