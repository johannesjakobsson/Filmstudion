using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Filmstudion.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Filmstudion.Models
{
    public class FilmStudioRepository : IFilmStudioRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<FilmStudioRepository> _logger;

        public FilmStudioRepository(AppDbContext context, 
            IMapper mapper, 
            ILogger<FilmStudioRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<FilmStudio> AllFilmStudios()
        {
            _logger.LogInformation("Get all filmstudio");

            var filmstudios = _context.FilmStudios;
            foreach(var studio in filmstudios)
            {
                studio.RentedFilmCopies = _context.FilmCopies.Where(fc => fc.FilmStudioId == studio.FilmStudioId).ToList();
            }

            return filmstudios;
        }

        public FilmStudio Register(RegisterFilmStudioResource model)
        {
            _logger.LogInformation("Register new FilmStudio");

            //validate
            if(_context.Users.Any(x => x.UserName == model.UserName))
            {
                throw new Exception("Username '" + model.UserName + "' is already taken");
            }

            if(_context.Users.Any(x => x.FilmStudioName == model.FilmStudioName))
            {
                throw new Exception("FilmStudioName '" + model.FilmStudioName + "' is already taken");
            }

            // map model to new user object
            var filmStudioUser = _mapper.Map<User>(model);
            filmStudioUser.Role = "Filmstudio"; //Tillfällig lösning

            //hash password
            filmStudioUser.PasswordHash = BCryptNet.HashPassword(model.Password);

            var filmStudio = _mapper.Map<FilmStudio>(model);

            //save filmstudio
            _context.FilmStudios.Add(filmStudio); 
            _context.SaveChanges();


            //_context.Entry(filmStudio).GetDatabaseValues();

            //find filmstudio and set ID
            var lastAddedStudio = _context.FilmStudios.FirstOrDefault(x => x.FilmStudioName == model.FilmStudioName);
            filmStudioUser.FilmStudioId = lastAddedStudio.FilmStudioId;
            filmStudio.FilmStudioId = lastAddedStudio.FilmStudioId;

            //save user
            _context.Users.Add(filmStudioUser);
            _context.SaveChanges();

            return filmStudio;
        }
        public FilmStudio GetFilmStudioById(int id)
        {
            _logger.LogInformation("Get a filmstudio");

            var filmstudio = _context.FilmStudios.FirstOrDefault(f => f.FilmStudioId == id);
            filmstudio.RentedFilmCopies = _context.FilmCopies.Where(fc => fc.FilmStudioId == id).ToList();

            return filmstudio;
        }

        public void RentAFilm(FilmStudio studio, FilmCopy filmCopy)
        {
            
            filmCopy.FilmStudioId = studio.FilmStudioId;
            filmCopy.RentedOut = true;
            var filmCopyList = new List<FilmCopy>();
            filmCopyList.Add(filmCopy);
            studio.RentedFilmCopies = filmCopyList;
            _context.FilmCopies.Update(filmCopy);
            _context.FilmStudios.Update(studio);
            _context.SaveChanges();
        }


    }
}