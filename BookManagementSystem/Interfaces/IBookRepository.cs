using dotNetBasic.Models;

namespace dotNetBasic.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksDB();
        Task<Book?> GetBookDB(int bookId);
        Task<List<Book>> GetBooksByGenreDB(string genre);
        Task AddBookDB(Book book);
        Task UpdateBookDb(Book book);
        Task DeleteBookDB(int bookId);
        Task<List<Book>> GetHighlightBooksDB();
    }
}