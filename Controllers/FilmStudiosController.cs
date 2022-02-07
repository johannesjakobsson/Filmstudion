using System;
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
    [Route("api/filmstudio")] // Ändra till [controller]??? Men i kraven står det filmstudio
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] DEN HÄR STRÄNGEN SKA FINNAS DÄR DET BEHÖVS AUTHORIZATION
    public class FilmStudiosController : ControllerBase
    {
        private IFilmStudioRepository _repository;
        private readonly IMapper _mapper;

        public FilmStudiosController(IFilmStudioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterFilmStudio model)
        {
            try
            {
                _repository.Register(model);
                return Ok(_mapper.Map<FilmStudio>(model));
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}