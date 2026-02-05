using dotNetBasic.DTO;
using dotNetBasic.Models;

namespace dotNetBasic.Interfaces
{


    public interface IBookService
    {
        Task <List<BooksDTO>> GetAllBooks();
        Task<List<BooksDTO>> GetBookByGenre(string genre);
        Task <BooksDTO?> GetBookDetails(int id);
        Task<List<BooksDTO>> GetHighlightBooks();
        Task AddBookAsync(Book book);
        Task<bool> UpdateBookAsync(Book book);
        Task<bool> DeleteBookAsync(int bookId);
    }
}