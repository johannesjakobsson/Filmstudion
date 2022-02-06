using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Filmstudion.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Film> Films {get; set;}
        public DbSet<FilmStudio> FilmStudios {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>().HasData(new Film 
            { 
                FilmId = 1, 
                Name = "Hej", 
                Director = "Hans", 
                Country = "Sweden", 
                ReleaseYear = 1991, 
                FilmCopies = {} //?
            });

            modelBuilder.Entity<FilmStudio>().HasData(new FilmStudio 
            { 
                FilmStudioId = 1,
                FilmStudioName = "FilmStudio-Gotland",
                FilmStudioCity = "Visby",
                Email = "Gotland@Gotland.se"
            });
        }
    }
}