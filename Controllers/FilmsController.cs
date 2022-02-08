using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Filmstudion.Models;
using Filmstudion.Resources;
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
        private readonly IMapper _mapper;


        public FilmsController(
            IFilmRepository filmRepository,
            IUserRepository userRepository,
            IFilmCopyRepository filmCopyRepository,
            IMapper mapper)
        {
            _filmRepository = filmRepository;
            _userRepository = userRepository;
            _filmCopyRepository = filmCopyRepository;
            _mapper = mapper;
        }

        [HttpPut]
        public IActionResult AddFilm(CreateFilmResource model)
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetFilms() //BEHÖVER LÄGGA TILL SÅ ATT FILMCOPIES ÄR SYNLIGA I ANROPET
        {
            try
            {
                var username = User.Identity.Name;
                var user = _userRepository.GetUserWithoutException(username);
                var films = _filmRepository.AllFilms;

                if(user == null)
                {
                    return Ok(_mapper.Map<FilmResponseResource[]>(films));
                }

                if(User.Identity.IsAuthenticated)
                {
                    return Ok(films.ToArray());
                }

                return BadRequest("Error getting filmstudio");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}