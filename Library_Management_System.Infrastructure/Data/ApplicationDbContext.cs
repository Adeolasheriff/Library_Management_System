
using Library_Management_System.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasQueryFilter(b => !b.IsDeleted);

            // Seed books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    ISBN = "9780547928227",
                    PublishedDate = new DateTime(1937, 9, 21)
                },
                new Book
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Title = "1984",
                    Author = "George Orwell",
                    ISBN = "9780451524935",
                    PublishedDate = new DateTime(1949, 6, 8)
                }
            );
        }

       
    }
}