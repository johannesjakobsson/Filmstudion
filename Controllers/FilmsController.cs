using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Filmstudion.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Filmstudion.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FilmsController : ControllerBase
    {
        private IFilmRepository _filmRepository;
        private IUserRepository _userRepository;
        private IFilmCopyRepository _filmCopyRepository;

        public FilmsController(
            IFilmRepository filmRepository,
            IUserRepository userRepository,
            IFilmCopyRepository filmCopyRepository)
        {
            _filmRepository = filmRepository;
            _userRepository = userRepository;
            _filmCopyRepository = filmCopyRepository;
        }

        [HttpPut]
        public IActionResult AddFilm(CreateFilm model)
        {
            try
            {
                var username = User.Identity.Name;
                var user = _userRepository.GetUser(username);

                if(!user.IsAdmin)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "User is not admin");
                }

                var film = _filmRepository.AddFilm(model);
                
                if(film != null)
                {
                    _filmCopyRepository.CreateCopies(film.FilmId, model.NumberOfCopies);
                }

                return Ok(film);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}