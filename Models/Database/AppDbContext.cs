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
        public DbSet<FilmCopy> FilmCopies {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // FILMER
            modelBuilder.Entity<Film>().HasData(new Film 
            { 
                FilmId = 1, 
                Name = "Avatar", 
                Director = "James Cameron", 
                Country = "United States", 
                ReleaseYear = 2009, 
            });
                        modelBuilder.Entity<Film>().HasData(new Film 
            { 
                FilmId = 2, 
                Name = "Law Abiding Citizen", 
                Director = "F. Gary Gray", 
                Country = "United States", 
                ReleaseYear = 2009, 
            });
                        modelBuilder.Entity<Film>().HasData(new Film 
            { 
                FilmId = 3, 
                Name = "Warrior", 
                Director = "Gavin O'Connor", 
                Country = "United States", 
                ReleaseYear = 2011, 
            });
                        modelBuilder.Entity<Film>().HasData(new Film 
            { 
                FilmId = 4, 
                Name = "The Wolf Of Wallstreet", 
                Director = "Martin Scorsese", 
                Country = "United States", 
                ReleaseYear = 2013, 
            });

            //Filmcopy
            modelBuilder.Entity<FilmCopy>().HasData(new FilmCopy
            { 
                FilmCopyId = 1, 
                FilmId = 1, 
                RentedOut = false, 
                FilmStudioId = 0,
            });
            modelBuilder.Entity<FilmCopy>().HasData(new FilmCopy
            { 
                FilmCopyId = 2, 
                FilmId = 1, 
                RentedOut = false, 
                FilmStudioId = 0,
            });
            modelBuilder.Entity<FilmCopy>().HasData(new FilmCopy
            { 
                FilmCopyId = 3, 
                FilmId = 1, 
                RentedOut = false, 
                FilmStudioId = 0,
            });
            modelBuilder.Entity<FilmCopy>().HasData(new FilmCopy
            { 
                FilmCopyId = 4, 
                FilmId = 2, 
                RentedOut = false, 
                FilmStudioId = 0,
            });
            modelBuilder.Entity<FilmCopy>().HasData(new FilmCopy
            { 
                FilmCopyId = 5, 
                FilmId = 2, 
                RentedOut = false, 
                FilmStudioId = 0,
            });
            modelBuilder.Entity<FilmCopy>().HasData(new FilmCopy
            { 
                FilmCopyId = 6, 
                FilmId = 3, 
                RentedOut = false, 
                FilmStudioId = 0,
            });
            modelBuilder.Entity<FilmCopy>().HasData(new FilmCopy
            { 
                FilmCopyId = 7, 
                FilmId = 4, 
                RentedOut = false, 
                FilmStudioId = 0,
            });
            modelBuilder.Entity<FilmCopy>().HasData(new FilmCopy
            { 
                FilmCopyId = 8, 
                FilmId = 4, 
                RentedOut = false, 
                FilmStudioId = 0,
            });
            modelBuilder.Entity<FilmCopy>().HasData(new FilmCopy
            { 
                FilmCopyId = 9, 
                FilmId = 4, 
                RentedOut = false, 
                FilmStudioId = 0,
            });
        }
    }
}