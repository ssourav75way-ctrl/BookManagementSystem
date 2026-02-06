using dotNetBasic.Data;
using dotNetBasic.Models;
using Microsoft.EntityFrameworkCore;

public static class Seeder
{
    public static void SeedDatabase(AppDbContext context)
    {
        Console.WriteLine("Seeder started...");

        context.Database.Migrate();

        if (context.Books.Any())
        {
            Console.WriteLine("Books already exist. Seeding skipped.");
            return;
        }

        Console.WriteLine("Seeding books...");

        var dummyBooks = new List<Book>
        {
            new Book
            {
                Title = "The Great Gatsby",
                Description = "Test",
                Author = "F. Scott Fitzgerald",
                Genre = "Fiction",
                AddedOn = DateTime.UtcNow,
                isAvailable = true,
                Createdby = "admin"
            }
        };

        context.Books.AddRange(dummyBooks);
        context.SaveChanges();

        Console.WriteLine("Seeding completed.");
    }
}
