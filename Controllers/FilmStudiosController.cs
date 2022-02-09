using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Filmstudion.Models;
using Filmstudion.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmstudion.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FilmStudiosController : ControllerBase
    {
        private IFilmStudioRepository _filmStudioRepository;
        private IUserRepository _userRepository;
        private IFilmCopyRepository _filmCopyRepository;
        private readonly IMapper _mapper;

        public FilmStudiosController(IFilmStudioRepository filmStudioRepository, 
        IMapper mapper, 
        IUserRepository userRepository,
        IFilmCopyRepository filmCopyRepository)
        {
            _filmStudioRepository = filmStudioRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterFilmStudioResource model)
        {
            try
            {
                var filmstudio = _filmStudioRepository.Register(model);
                return Ok(filmstudio);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        
        [AllowAnonymous]
        [HttpGet]   
        public IActionResult GetAllFilmstudios() 
        {
            try
            {
                var username = User.Identity.Name;
                var user = _userRepository.GetUserWithoutException(username);
                var studios = _filmStudioRepository.AllFilmStudios();

                if(user == null || !user.IsAdmin)
                {
                    return Ok(_mapper.Map<FilmStudiosResponseResource[]>(studios));
                }
                else if(user.IsAdmin)
                {
                    return Ok(studios.ToArray());
                }
                return BadRequest("Error getting all filmstudios");
            }
            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public IActionResult GetFilmStudio(int id) // SKA RETURNERA EN ARRAY AV OBJEKT INTE BARA OBJEKT
        {
            try
            {
                var username = User.Identity.Name;
                var user = _userRepository.GetUserWithoutException(username);
                var studio = _filmStudioRepository.GetFilmStudioById(id);

                if(studio == null)
                {
                    throw new Exception("No studio found");
                }

                if(user == null)
                {
                    return Ok(_mapper.Map<FilmStudiosResponseResource>(studio));
                }

                if(user.FilmStudioId == id || user.IsAdmin)
                {
                    return Ok(studio);
                }
                else if (!user.IsAdmin)
                {
                    return Ok(_mapper.Map<FilmStudiosResponseResource>(studio));
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