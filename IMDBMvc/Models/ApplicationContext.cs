using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMDBMvc.Models
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options): 
        IdentityDbContext<ApplicationUser, IdentityRole, string>(options)
    {
        public required DbSet<Movie> Movies { get; set; }
        public required DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, GenreName = "Action" },
                new Genre { Id = 2, GenreName = "Comedy" },
                new Genre { Id = 3, GenreName = "Drama" },
                new Genre { Id = 4, GenreName = "Horror" },
                new Genre { Id = 5, GenreName = "Sci-Fi" }
            );

            modelBuilder.Entity<Movie>().HasData(

                new Movie()
                {
                    Id = 1,
                    Title = "Star Wars: Episode IV - A New Hope",
                    Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, " +
                    "a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, " +
                    "while also attempting to rescue Princess Leia from the mysterious Darth Vader.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BOGUwMDk0Y2MtNjBlNi00NmRiLTk2MWYtMGMyMDlhYmI4ZDBjXkEyXkFqcGc@._V1_.jpg",
                    Rating = 8,
                    GenreId = 5

                },
                new Movie()
                {
                    Id = 2,
                    Title = "Star Wars: Episode V - The Empire Strikes Back",
                    Description = "After the Empire overpowers the Rebel Alliance, " +
                    "Luke Skywalker begins his Jedi training with Yoda. At the same time, " +
                    "Darth Vader and bounty hunter Boba Fett pursue his friends across the galaxy.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTkxNGFlNDktZmJkNC00MDdhLTg0MTEtZjZiYWI3MGE5NWIwXkEyXkFqcGc@._V1_.jpg",
                    Rating = 8,
                    GenreId = 5
                },
                new Movie()
                {
                    Id = 3,
                    Title = "Star Wars: Episode VI - Return of the Jedi",
                    Description = "After a daring mission to rescue Han Solo from Jabba the Hutt, " +
                    "the Rebels dispatch to Endor to destroy the second Death Star. " +
                    "Meanwhile, Luke struggles to help Darth Vader back from the dark side without falling into the Emperor's trap.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BNWEwOTI0MmUtMGNmNy00ODViLTlkZDQtZTg1YmQ3MDgyNTUzXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg",
                    Rating = 8,
                    GenreId = 5
                }
            );

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);
        }
    }
}
