using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>()
                .HasKey(f => new { f.MovieId, f.UserId });

            modelBuilder.Entity<MovieCast>()
                .HasKey(MovieCast => new { MovieCast.CastId, MovieCast.Character, MovieCast.MovieId });

            modelBuilder.Entity<MovieGenre>()
                .HasKey(MovieGenre => new { MovieGenre.GenreId, MovieGenre.MovieId });

            modelBuilder.Entity<Purchase>()
                .HasKey(Purchase => new { Purchase.MovieId, Purchase.UserId });

            modelBuilder.Entity<Review>()
                .HasKey(Review => new { Review.MovieId, Review.UserId });

            modelBuilder.Entity<UserRole>()
                .HasKey(UserRole => new { UserRole.RoleId, UserRole.UserId });

            base.OnModelCreating(modelBuilder);
        }
    }
}