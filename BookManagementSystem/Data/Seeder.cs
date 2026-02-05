using dotNetBasic.Models;

namespace dotNetBasic.Data
{
    public static class Seeder
    {
        public static void SeedDatabase(AppDbContext context)
        {
            // Check if books already exist
            if (context.Books.Any())
            {
                return; // Database already seeded
            }

            var dummyBooks = new List<Book>
            {
                new Book
                {
                    Title = "The Great Gatsby",
                    Description = "A classic novel about wealth, love, and the American Dream set in the 1920s.",
                    Author = "F. Scott Fitzgerald",
                    Genre = "Fiction",
                    AddedOn = DateTime.UtcNow.AddDays(-30),
                    isAvailable = true,
                    Createdby = "admin"
                },
                new Book
                {
                    Title = "To Kill a Mockingbird",
                    Description = "A gripping tale of racial injustice and childhood innocence in the American South.",
                    Author = "Harper Lee",
                    Genre = "Fiction",
                    AddedOn = DateTime.UtcNow.AddDays(-25),
                    isAvailable = true,
                    Createdby = "admin"
                },
                new Book
                {
                    Title = "1984",
                    Description = "A dystopian novel depicting a totalitarian state and the struggle for freedom.",
                    Author = "George Orwell",
                    Genre = "Dystopian",
                    AddedOn = DateTime.UtcNow.AddDays(-20),
                    isAvailable = true,
                    Createdby = "admin"
                },
                new Book
                {
                    Title = "Pride and Prejudice",
                    Description = "A romantic novel exploring love, marriage, and social class in Georgian England.",
                    Author = "Jane Austen",
                    Genre = "Romance",
                    AddedOn = DateTime.UtcNow.AddDays(-15),
                    isAvailable = true,
                    Createdby = "admin"
                },
                new Book
                {
                    Title = "The Catcher in the Rye",
                    Description = "A coming-of-age novel following the adventures of Holden Caulfield in New York City.",
                    Author = "J.D. Salinger",
                    Genre = "Fiction",
                    AddedOn = DateTime.UtcNow.AddDays(-10),
                    isAvailable = true,
                    Createdby = "admin"
                },
                new Book
                {
                    Title = "Sapiens",
                    Description = "A fascinating exploration of human history from the Stone Age to the modern world.",
                    Author = "Yuval Noah Harari",
                    Genre = "Non-Fiction",
                    AddedOn = DateTime.UtcNow.AddDays(-8),
                    isAvailable = true,
                    Createdby = "admin"
                },
                new Book
                {
                    Title = "The Hobbit",
                    Description = "An epic fantasy adventure following Bilbo Baggins on an unexpected quest.",
                    Author = "J.R.R. Tolkien",
                    Genre = "Fantasy",
                    AddedOn = DateTime.UtcNow.AddDays(-7),
                    isAvailable = true,
                    Createdby = "admin"
                },
                new Book
                {
                    Title = "Educated",
                    Description = "A powerful memoir about a woman's journey from a survivalist family to academic success.",
                    Author = "Tara Westover",
                    Genre = "Biography",
                    AddedOn = DateTime.UtcNow.AddDays(-5),
                    isAvailable = true,
                    Createdby = "admin"
                },
                new Book
                {
                    Title = "The Silent Patient",
                    Description = "A psychological thriller with shocking twists that will keep you guessing until the end.",
                    Author = "Alex Michaelides",
                    Genre = "Thriller",
                    AddedOn = DateTime.UtcNow.AddDays(-3),
                    isAvailable = true,
                    Createdby = "admin"
                },
                new Book
                {
                    Title = "Atomic Habits",
                    Description = "A practical guide to building good habits and breaking bad ones through small changes.",
                    Author = "James Clear",
                    Genre = "Self-Help",
                    AddedOn = DateTime.UtcNow.AddDays(-1),
                    isAvailable = true,
                    Createdby = "admin"
                }
            };

            context.Books.AddRange(dummyBooks);
            context.SaveChanges();
        }
    }
}
