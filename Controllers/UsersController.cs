using System;
using AutoMapper;
using Filmstudion.Models;
using Filmstudion.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmstudion.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class UsersController : ControllerBase
    {
        private IRegisterUserRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IRegisterUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
    }
}