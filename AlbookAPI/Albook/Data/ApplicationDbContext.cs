using Albook.Configurations;
using Albook.Models.Domain;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Category> Categories { get; set; }
        public DbSet<BooksCategories> BooksCategories { get; set; }
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<BooksChapter> BooksChapters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BooksCategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookReviewConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new TranslationConfiguration());
        //    modelBuilder.ApplyConfiguration(new ChaptersConfiguration());

            // Configuring primary keys

            //modelBuilder.Entity<Book>()
            //.HasMany(b => b.Categories)
            //.WithMany(c => c.Books)
            //.UsingEntity<Dictionary<string, object>>(
            //    "BookCategory",
            //    j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
            //    j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"));

            // You can add further configurations depending on your specific needs
        }

    }
}
