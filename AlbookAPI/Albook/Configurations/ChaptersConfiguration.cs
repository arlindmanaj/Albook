using Albook.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albook.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.HasKey(c => c.ChapterId);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Content)
                .IsRequired(); // You can set a length or leave it flexible

            builder.HasOne(c => c.Book)
                .WithMany(b => b.Chapter)
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.Cascade); // If a book is deleted, its chapters are also deleted

            builder.Property(c => c.ChapterNumber)
                .IsRequired();
        }
    }
}
