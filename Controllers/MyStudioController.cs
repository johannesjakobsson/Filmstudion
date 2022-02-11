using System;
using AutoMapper;
using Filmstudion.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmstudion.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MyStudioController : ControllerBase
    {
        private IFilmStudioRepository _filmStudioRepository;
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public MyStudioController(IFilmStudioRepository filmStudioRepository, 
        IMapper mapper, 
        IUserRepository userRepository)
        {
            _filmStudioRepository = filmStudioRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("rentals")]
        public IActionResult Rentals()
        {
            try
            {
                var username = User.Identity.Name;
                var user = _userRepository.GetUser(username);

                if(user.Role != "Filmstudio") return Unauthorized("Can't find a filmstudio in this account");

                var filmstudio = _filmStudioRepository.GetFilmStudioById(user.FilmStudioId);

                return Ok(filmstudio.RentedFilmCopies.ToArray());
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }
    }
}