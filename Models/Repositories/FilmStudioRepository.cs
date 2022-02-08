using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Filmstudion.Resources;
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

        public IEnumerable<FilmStudio> AllFilmStudios { get { return _context.FilmStudios; } }

        public FilmStudio Register(RegisterFilmStudioResource model)
        {
            _logger.LogInformation("Register new FilmStudio");

            //validate
            if(_context.Users.Any(x => x.UserName == model.UserName))
            {
                throw new Exception("Username '" + model.UserName + "' is already taken");
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

            return _context.FilmStudios.FirstOrDefault(f => f.FilmStudioId == id);
        }


    }
}