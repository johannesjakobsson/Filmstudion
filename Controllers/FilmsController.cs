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
                foreach(var film in films )
                {
                    film.FilmCopies = _filmCopyRepository.GetFilmCopies(film.FilmId).ToArray();
                }

                if(user == null)
                {
                    return Ok(_mapper.Map<FilmResponseResource[]>(films));
                }

                if(User.Identity.IsAuthenticated)
                {
                    return Ok(films.ToArray());
                }

                return BadRequest("Error getting films");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public IActionResult GetFilm(int id) 
        {
            try
            {
                var username = User.Identity.Name;
                var user = _userRepository.GetUserWithoutException(username);
                var film = _filmRepository.GetFilmById(id);
                film.FilmCopies = _filmCopyRepository.GetFilmCopies(film.FilmId).ToArray();

                if(user == null)
                {
                    return Ok(_mapper.Map<FilmResponseResource>(film));
                }

                if(User.Identity.IsAuthenticated)
                {
                    return Ok(film);
                }

                return BadRequest("Error getting film");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult EditFilm(int id, EditFilmResource model)
        {
            try
            {
                var username = User.Identity.Name;
                var user = _userRepository.GetUser(username);

                if(!user.IsAdmin) return Unauthorized(new {message = "Only admins allowed"});

                var newFilm = _filmRepository.EditFilmById(id, model);
                var result = _mapper.Map<EditFilmResponseResource>(newFilm);
                result.FilmCopies = _filmCopyRepository.GetFilmCopies(id).ToArray();
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        } 

/*         [HttpPatch("{id:int}")]
        public IActionResult EditFilmCopys(int id, EditFilmCopiesResource model)
        {
            try
            {
                var username = User.Identity.Name;
                var user = _userRepository.GetUser(username);

                if(!user.IsAdmin) return Unauthorized(new {message = "Only admins allowed"});

                var newFilmcopies = _filmCopyRepository.EditFilmCopies(id, model);
                var film = _filmRepository.GetFilmById(id);
                film.FilmCopies = newFilmcopies;

                return Ok(film);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        } */
    }
}