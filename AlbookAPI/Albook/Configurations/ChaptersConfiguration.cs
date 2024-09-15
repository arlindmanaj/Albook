using Albook.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albook.Configurations
{
    //public class ChaptersConfiguration : IEntityTypeConfiguration<Chapters>
    //{
    //    public void Configure(EntityTypeBuilder<Chapters> builder)
    //    {
    //        // Configure the primary key
    //        builder.HasKey(c => c.ChapterId);

    //        // Configure properties
    //        builder.Property(c => c.Title)
    //               .IsRequired()
    //               .HasMaxLength(255);  // Optional: Set a max length for the title

    //        builder.Property(c => c.Content)
    //               .IsRequired();  // The content should be required

    //        builder.Property(c => c.Order)
    //               .IsRequired();  // Each chapter should have an order

    //        // Configure the relationship with Book
    //        builder.HasOne(c => c.Book)
    //               .WithMany(b => b.Chapters)
    //               .HasForeignKey(c => c.BookId)
    //               .OnDelete(DeleteBehavior.Cascade);  // Delete chapters if the book is deleted
    //    }
    //}
}
