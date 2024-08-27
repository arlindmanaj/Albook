using Albook.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Albook.Configurations
{
    public class TranslationConfiguration : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.HasKey(tr => tr.TranslationId);

            builder.HasOne(tr => tr.Book)
                .WithMany(b => b.Translations)
                .HasForeignKey(tr => tr.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
