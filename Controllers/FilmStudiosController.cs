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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //DEN HÄR STRÄNGEN SKA FINNAS DÄR DET BEHÖVS AUTHORIZATION
    public class FilmStudiosController : ControllerBase
    {
        private IFilmStudioRepository _filmStudioRepository;
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public FilmStudiosController(IFilmStudioRepository filmStudioRepository, IMapper mapper, IUserRepository userRepository)
        {
            _filmStudioRepository = filmStudioRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("api/filmstudio/register")]
        public IActionResult Register(RegisterFilmStudioResource model)
        {
            try
            {
                _filmStudioRepository.Register(model);
                return Ok(_mapper.Map<FilmStudio>(model));
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        
        [AllowAnonymous]
        [HttpGet("api/[controller]")]   
        public IActionResult GetAllFilmstudios() 
        {
            try
            {
                var username = User.Identity.Name;
                var user = _userRepository.GetUserWithoutException(username);
                var studios = _filmStudioRepository.AllFilmStudios;

                if(user == null || !user.IsAdmin)
                {
                    return Ok(_mapper.Map<GetAllFilmStudiosResponseResource[]>(studios));
                }
                else if(user.IsAdmin)
                {
                    return Ok(studios.ToList());
                }
                return BadRequest("Error getting all filmstudios");
            }
            catch (Exception ex)
            {
                 return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}