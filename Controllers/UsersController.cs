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
        private IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;

        public UsersController(IUserRepository repository, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegister model)
        {
            try
            {
                _repository.Register(model);
                var user = _repository.GetUser(model.UserName);
                return Ok(_mapper.Map<UserResponse>(user));
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserAuthenticate model)
        {
            try
            {
                var response = _repository.Authenticate(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}