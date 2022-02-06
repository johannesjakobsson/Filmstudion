using System;
using System.Linq;
using AutoMapper;
using Filmstudion.Resources;
using Microsoft.Extensions.Logging;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Filmstudion.Models
{
    public class RegisterFilmStudioRepository : IRegisterFilmStudioRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<RegisterFilmStudioRepository> _logger;

        public RegisterFilmStudioRepository(AppDbContext context, 
            IMapper mapper, 
            ILogger<RegisterFilmStudioRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public void Register(RegisterFilmStudio model)
        {
            _logger.LogInformation("Register new FilmStudio");

            //validate
            if(_context.Users.Any(x => x.UserName == model.UserName))
            {
                throw new Exception("Username '" + model.UserName + "' is already taken");
            }

            // map model to new user object
            var filmStudio = _mapper.Map<User>(model);

            //hash password
            filmStudio.PasswordHash = BCryptNet.HashPassword(model.Password);

            //save user and filmstudio
            _context.FilmStudios.Add(_mapper.Map<FilmStudio>(model)); 
            _context.Users.Add(filmStudio);
            _context.SaveChanges();
        }
    }
}