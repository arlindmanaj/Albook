using Albook.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albook.Configurations
{
    public class BooksCategoriesConfiguration : IEntityTypeConfiguration<BooksCategories>
    {
        public void Configure(EntityTypeBuilder<BooksCategories> builder)
        {
            // Set the table name explicitly (if needed)
            builder.ToTable("BooksCategories");

            // Set the primary key
            builder.HasKey(bc => bc.BookCategoryId);

            // Configure the relationship with Book
            builder.HasOne(bc => bc.Book)
                   .WithMany(b => b.BooksCategories)
                   .HasForeignKey(bc => bc.BookId);

            // Configure the relationship with Category
            builder.HasOne(bc => bc.Category)
                   .WithMany(c => c.BooksCategories)
                   .HasForeignKey(bc => bc.CategoryId);
        }

    }
}
