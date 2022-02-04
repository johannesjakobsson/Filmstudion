using Microsoft.EntityFrameworkCore;

namespace Filmstudion.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Film> Films {get; set;}
        public DbSet<FilmStudio> FilmStudios {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User 
            {
                UserId = 1,
                Username = "jajoo",
                Role = "Admin",
                IsAdmin = true,
                Password = "test",
                FilmStudioId = 1
            });

            modelBuilder.Entity<Film>().HasData(new Film 
            { 
                FilmId = 1, 
                Name = "Hej", 
                Director = "Hans", 
                Country = "Sweden", 
                ReleaseYear = 1991, 
                FilmCopies = 5
            });

            modelBuilder.Entity<FilmStudio>().HasData(new FilmStudio 
            { 
                FilmStudioId = 1,
                Name = "FilmStudio-Gotland",
                Location = "Gotland",
                Email = "Gotland@Gotland.se",
                ContactPerson = "Göran"
            });
        }
    }
}