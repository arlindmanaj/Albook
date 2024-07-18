using Microsoft.EntityFrameworkCore;
using Albook.Models.Domain;
using System.Collections.Generic;

namespace Albook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }

       
    }
}
