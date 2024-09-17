using Albook.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Albook.Configurations
{
    public class BooksChaptersConfiguration : IEntityTypeConfiguration<BooksChapter>
    {
        public void Configure(EntityTypeBuilder<BooksChapter> builder)
        {
            // Set the table name explicitly (if needed)
            builder.ToTable("BooksChapters");

            // Set the primary key (composite key)
            builder.HasKey(bc => bc.BooksChapterId);

            // Configure the relationship with Book
            builder.HasOne(bc => bc.Book)
                .WithMany(b => b.BooksChapter)
                .HasForeignKey(bc => bc.BookId);

            // Configure the relationship with Chapter
            builder.HasOne(bc => bc.Chapter)
                .WithMany(c => c.BooksChapter)
                .HasForeignKey(bc => bc.ChapterId);

            // Ensure required fields
            builder.Property(bc => bc.BookId).IsRequired();
            builder.Property(bc => bc.ChapterId).IsRequired();
        }

    }
    
}
