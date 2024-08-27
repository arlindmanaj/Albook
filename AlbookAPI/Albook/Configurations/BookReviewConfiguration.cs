using Albook.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Albook.Configurations
{
    public class BookReviewConfiguration : IEntityTypeConfiguration<BookReview>
    {
        public void Configure(EntityTypeBuilder<BookReview> builder)
        {

            builder.HasKey(br => br.ReviewId);

            // Configure the relationship with Book
            builder.HasOne(br => br.Book)
                .WithMany(b => b.BookReviews)
                .HasForeignKey(br => br.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the relationship with Category
            builder.HasOne(br => br.User)
                .WithMany(u => u.BookReviews)
                .HasForeignKey(br => br.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}