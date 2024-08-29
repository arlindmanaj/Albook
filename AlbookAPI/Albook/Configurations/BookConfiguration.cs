using Albook.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albook.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            // Configuring primary key
            builder.HasKey(b => b.BookId);

            // Configuring string properties
            builder.Property(b => b.BookId)
                   .HasColumnType("nvarchar(255)")
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                   .IsRequired();

            builder.Property(b => b.Author)
                   .IsRequired();

            // Configuring relationships
            builder.HasMany(b => b.BookReviews)
                   .WithOne()
                   .HasForeignKey(br => br.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.Transactions)
                   .WithOne()
                   .HasForeignKey(t => t.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.Translations)
                   .WithOne()
                   .HasForeignKey(tr => tr.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.BooksCategories)
                   .WithOne(bc => bc.Book)
                   .HasForeignKey(bc => bc.BookId);
        }
    }
}