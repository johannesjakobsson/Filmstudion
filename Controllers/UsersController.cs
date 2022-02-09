using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Filmstudion.Models;
using Filmstudion.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Filmstudion.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IFilmStudioRepository _filmStudioRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper, IFilmStudioRepository filmStudioRepository)
        {
            _userRepository = userRepository;
            _filmStudioRepository = filmStudioRepository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterResource model)
        {
            try
            {
                var user = _userRepository.Register(model);
                return Ok(_mapper.Map<UserResponseResource>(user));
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserAuthenticateResource model)
        {
            try
            {
                var user = _userRepository.Authenticate(model);
                if(user.Role == "Admin")
                {
                    return Ok(_mapper.Map<AuthenticateResponseResource>(user));
                }
                else{
                    var filmStudioUser = _mapper.Map<FilmStudioAuthenticateResponseResource>(user);
                    filmStudioUser.FilmStudio = _filmStudioRepository.GetFilmStudioById(filmStudioUser.FilmStudioId);
                    return Ok(filmStudioUser);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}