using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Filmstudion.Models
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<RegisterUserRepository> _logger;

        public RegisterUserRepository(AppDbContext context, 
            IMapper mapper, 
            ILogger<RegisterUserRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public void Register(UserRegister model)
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
            _context.SaveChanges();
        }
        public User GetUser(string userName)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName);
            if (user == null) throw new Exception("User not found");
            return user;
        }
    }
}
