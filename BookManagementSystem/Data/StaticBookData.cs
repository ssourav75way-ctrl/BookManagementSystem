using dotNetBasic.Models;


namespace dotNetBasic.Data
{
    public static class BookData
    {
        public static List<Book> Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "The Alchemist",
                Description = "A story about a shepherd who travels to find treasure and discovers life lessons.",
                Author = "Paulo Coelho",
                Genre = "Fiction",
                isAvailable = true,
                AddedOn = new DateTime(2026, 2, 3)
            },
            new Book
            {
                Id = 2,
                Title = "Clean Code",
                Description = "A handbook of agile software craftsmanship.",
                Author = "Robert C. Martin",
                Genre = "Programming",
                isAvailable = false,
                AddedOn = new DateTime(2022, 8, 15)
            },
            new Book
            {
                Id = 3,
                Title = "Harry Potter and the Sorcerer's Stone",
                Description = "The first book in the Harry Potter series, introducing the wizarding world.",
                Author = "J.K. Rowling",
                Genre = "Fantasy",
                isAvailable = true,
                AddedOn = new DateTime(2021, 11, 20)
            },
            new Book
            {
                Id = 4,
                Title = "Atomic Habits",
                Description = "An easy & proven way to build good habits and break bad ones.",
                Author = "James Clear",
                Genre = "Self-Help",
                isAvailable = true,
                AddedOn = new DateTime(2023, 3, 5)
            },
            new Book
            {
                Id = 5,
                Title = "The Pragmatic Programmer",
                Description = "From journeyman to master — essential software development guide.",
                Author = "Andrew Hunt & David Thomas",
                Genre = "Programming",
                isAvailable = false,
                AddedOn = new DateTime(2020, 5, 18)
            }
        };
    }
}
