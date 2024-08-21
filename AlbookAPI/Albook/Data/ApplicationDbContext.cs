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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring primary keys
            modelBuilder.Entity<Book>()
                .HasKey(b => b.BookId);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<BookReview>()
                .HasKey(br => br.ReviewId);

            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);

            modelBuilder.Entity<Translation>()
                .HasKey(tr => tr.TranslationId);

            // Configuring relationships (foreign keys)
            modelBuilder.Entity<BookReview>()
                .HasOne(br => br.Book)
                .WithMany(b => b.BookReviews)
                .HasForeignKey(br => br.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookReview>()
                .HasOne(br => br.User)
                .WithMany(u => u.BookReviews)
                .HasForeignKey(br => br.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Book)
                .WithMany(b => b.Transactions)
                .HasForeignKey(t => t.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Translation>()
                .HasOne(tr => tr.Book)
                .WithMany(b => b.Translations)
                .HasForeignKey(tr => tr.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring string properties to use the nvarchar(max) type in SQL Server
            modelBuilder.Entity<Book>()
                .Property(b => b.BookId)
                .HasColumnType("nvarchar(255)")
                .ValueGeneratedOnAdd(); // Assuming BookId is a GUID or similar unique identifier

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            // Adding additional configurations
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.Author)
                .IsRequired();

            // You can add further configurations depending on your specific needs
        }

    }
}
