using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Albook.Data;
using Albook.Models.Domain;
public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Check if any books exist
            if (context.Books.Any())
            {
                return; // DB has been seeded
            }

            // Add initial books
            context.Books.AddRange(
                new Book
                {
                    Title = "48 Ligjet e pushtetit",
                    Author = "Robert Greene",
                    Description = "Ky liber perfshin 48 ligje per tu mbrojtur apo per ti perdorur ndaj pushtetit dhe arritjes se pushtetit ne qfaredo menyre",
                    Language = "Shqip, Anglisht",
                    CoverUrl = "https://m.media-amazon.com/images/I/611X8GI7hpL._AC_UF1000,1000_QL80_.jpg",
                    ContentUrl = "http://example.com/content1.pdf",
                    Price = 24,
                    PublishedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                },
                new Book
                {
                    Title = "Te Jashtezakonshmit",
                    Author = "Malcolm Gladwell",
                    Description = "Ky liber perfshin disa karakteristika per disa histori suksesi nga njerez te famshem nga Bill Gates e deri tek sportiste te njohur.",
                    Language = "Shqip, Anglisht",
                    CoverUrl = "https://cronkitehhh.jmc.asu.edu/wp-content/uploads/2012/04/41lzLPREH1L._SS400_.jpg",
                    ContentUrl = "http://example.com/content2.pdf",
                    Price = 15.99m,
                    PublishedAt = DateTime.Now,
                    CreatedAt = DateTime.Now
                }
            );

            // Add initial users
            context.Users.AddRange(
                new User
                {
                    Username = "admin",
                    PasswordHash = "admin123", // Ensure you hash the password in a real application
                    Email = "admin@gmail.com",
                    Role = "Admin"
                },
                new User
                {
                    Username = "user1",
                    PasswordHash = "user123", // Ensure you hash the password in a real application
                    Email = "user@gmail.com",
                    Role = "Reader"
                }
            );

            context.SaveChanges();
        }
    }
}
