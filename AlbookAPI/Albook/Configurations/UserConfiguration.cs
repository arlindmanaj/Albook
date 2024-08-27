using Albook.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albook.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configuring primary key
            builder.HasKey(u => u.UserId);

            // Configuring string properties
            builder.Property(u => u.Username)
                   .HasColumnType("nvarchar(255)")
                   .IsRequired();

            // Configuring relationships
            builder.HasMany(u => u.BookReviews)
                   .WithOne(br => br.User)
                   .HasForeignKey(br => br.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
