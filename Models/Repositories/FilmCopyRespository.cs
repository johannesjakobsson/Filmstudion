using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Filmstudion.Resources;
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
            _logger.LogInformation("Deleting old film-copies");

            var currentCopiesArray = currentCopies.ToArray();
            var counter = currentCopiesArray.Length;
            for(int i = counter - 1; i >= newCopies; i--)
            {
                if(isCopyRentedOut(currentCopiesArray[i]))
                {
                    continue;
                }
                _context.Remove(currentCopiesArray[i]);
                _context.SaveChanges();
            }
        }

        public IEnumerable<FilmCopy> GetFilmCopies(int filmId)
        {
            return _context.FilmCopies.Where(fc => fc.FilmId == filmId);
        }

        public IEnumerable<FilmCopy> EditFilmCopies( int id, EditFilmResource model)
        {
            var filmCopies = GetFilmCopies(id);

            if (filmCopies == null) throw new Exception("FilmCopies not found");

            var numberOfCopies = filmCopies.ToList().Count();

            if(numberOfCopies != model.NumberOfCopies)
                {

                    if(numberOfCopies > model.NumberOfCopies)
                    {
                        var newCopies = model.NumberOfCopies;
                        var currentCopies = GetFilmCopies(id);
                        DeleteCopies(newCopies, currentCopies);
                    }
                    else if (numberOfCopies < model.NumberOfCopies)
                    {
                        CreateCopies(id, model.NumberOfCopies, numberOfCopies);
                    }
                }

            var newFilmCopies = GetFilmCopies(id);
            return newFilmCopies;
        }

        public bool isFilmCopyAvailable(int filmId)
        {
            var filmCopies = _context.FilmCopies
                .Where(fc => fc.RentedOut == false)
                .Where(f => f.FilmId == filmId);

            if (filmCopies.ToList().Count() > 0) return true;

            return false;
        }

        public bool isFilmRentedByThisFilmStudio(int filmId, int studioId)
        {
            var filmCopies = _context.FilmCopies
                .Where(f => f.FilmId == filmId)
                .Where(fc => fc.FilmStudioId == studioId);

            if(filmCopies.ToList().Count() > 0) return true;

            return false;
        }

        public FilmCopy GetAvailableFilmCopy(int filmId)
        {
            return _context.FilmCopies
                .Where(f => f.FilmId == filmId)
                .FirstOrDefault(fc => fc.RentedOut == false);
        }

        public FilmCopy GetRentedFilmCopy(int filmId, int studioId)
        {
            return _context.FilmCopies
                .Where(f => f.FilmId == filmId)
                .FirstOrDefault(fc => fc.FilmStudioId == studioId);
        }

        private bool isCopyRentedOut(FilmCopy copy)
        {
            if(copy.RentedOut == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}