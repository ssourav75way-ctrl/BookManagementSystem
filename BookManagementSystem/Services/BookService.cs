using dotNetBasic.DTO;
using dotNetBasic.Interfaces;
using dotNetBasic.Models;
using dotNetBasic.Repository;

namespace dotNetBasic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }

        // Mapper from Book to BooksDTO
        private static BooksDTO MapToBookDTO(Book book)
        {
            return new BooksDTO
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Genre = book.Genre,
                AddedOn = book.AddedOn,
                Description = book.Description
            };
        }

        public async Task<List<BooksDTO>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksDB();
            return books.Select(MapToBookDTO).ToList();
        }

        public async Task<List<BooksDTO>> GetBookByGenre(string genre)
        {
            var books = await _bookRepository.GetBooksByGenreDB(genre);
            return books.Select(MapToBookDTO).ToList();
        }

        public async Task<BooksDTO?> GetBookDetails(int id)
        {
            var book = await _bookRepository.GetBookDB(id);
            if (book == null)
                return null;
            return MapToBookDTO(book);
        }

       
        public async Task<List<BooksDTO>> GetHighlightBooks()
        {
            var books = await _bookRepository.GetHighlightBooksDB();

            return books.Select(book => new BooksDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Description = book.Description,
                AddedOn = book.AddedOn
            }).ToList();
        }

        
        public async Task AddBookAsync(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Book title cannot be empty");

            await _bookRepository.AddBookDB(book);
        }
        
        public async Task<bool> UpdateBookAsync(Book book)
        {
            var existing = await _bookRepository.GetBookDB(book.Id);
            if (existing == null)
                throw new KeyNotFoundException("Book not found");
            await _bookRepository.UpdateBookDb(book);
            return true;
        }

     
        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var existing = await _bookRepository.GetBookDB(bookId);
            if (existing == null)
                throw new KeyNotFoundException("Book not found");

            await _bookRepository.DeleteBookDB(bookId);
            return true;
        }
    }
}
