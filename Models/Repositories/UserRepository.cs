using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Filmstudion.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Filmstudion.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRepository> _logger;
        private readonly IConfiguration _config;

        public UserRepository(AppDbContext context, 
            IMapper mapper, 
            ILogger<UserRepository> logger,
            IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _config = config;
        }

        public User Register(UserRegisterResource model)
        {
            _logger.LogInformation("Register new Admin");

            // validate if IsAdmin is true
            if(!model.IsAdmin)
            {
                throw new Exception("User needs to be admin to get registered");
            }

            //validate if username is taken
            if(_context.Users.Any(x => x.UserName == model.UserName))
            {
                throw new Exception("Username '" + model.UserName + "' is already taken");
            }

            // map model to new user object
            var admin = _mapper.Map<User>(model);
            //hash password
            admin.PasswordHash = BCryptNet.HashPassword(model.Password);
            admin.Role = "Admin"; // Tillfällig lösning!

            _context.Users.Add(admin);
            admin.UserId = admin.Id;
            _context.SaveChanges();
            return admin;
        }
        public User GetUser(string userName)
        {
            _logger.LogInformation("Getting user by username");
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null) throw new Exception("User not found");
            return user;
        }

        public User GetUserWithoutException(string userName)
        {
            _logger.LogInformation("Getting user by username");
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName);
            return user;
        }

        public User Authenticate(UserAuthenticateResource model)
        {
            _logger.LogInformation("Authenticates User or Filmstudio");

            var user = _context.Users.SingleOrDefault(x => x.UserName == model.UserName);

            //validate
            if(user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                throw new Exception("Username or password is incorrect");

            //create token
            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Tokens:Issuer"], 
                _config["Tokens:Audience"], 
                claims,
                signingCredentials: creds,
                expires: DateTime.UtcNow.AddDays(1)
            );

            user.Token = new JwtSecurityTokenHandler().WriteToken(token);
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
