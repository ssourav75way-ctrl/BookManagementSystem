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
            List<Book> books = await _bookRepository.GetAllBooksDB();
            return books.Select(MapToBookDTO).ToList();
        }

        public async Task<List<BooksDTO>> GetBookByGenre(string genre)
        {
            List<Book> books = await _bookRepository.GetBooksByGenreDB(genre);
            return books.Select(MapToBookDTO).ToList();
        }

        public async Task<BooksDTO?> GetBookDetails(int id)
        {
            Book book = await _bookRepository.GetBookDB(id);
            if (book == null)
                return null;
            return MapToBookDTO(book);
        }

       
        public async Task<List<BooksDTO>> GetHighlightBooks()
        {
            List<Book> books = await _bookRepository.GetHighlightBooksDB();

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

        public async Task<List<string>> GetAllGenres()
        {
            List<Book> books = await _bookRepository.GetAllBooksDB();
            return books
                .Select(b => b.Genre)
                .Where(g => !string.IsNullOrEmpty(g))
                .Distinct()
                .OrderBy(g => g)
                .ToList();
        }

        
        public async Task AddBookAsync(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Book title cannot be empty");

            await _bookRepository.AddBookDB(book);
        }
        
        public async Task<Book?> UpdateBookAsync(UpdateBookDTO dto)
        {
            Book existing = await _bookRepository.GetBookDB(dto.Id);
            if (existing == null)
                return null;

            existing.Title = dto.Title;
            existing.Description = dto.Description;
            existing.Author = dto.Author;
            existing.Genre = dto.Genre;
            existing.UpdatedAt = DateTime.UtcNow;
            existing.Updatedby = "admin";

            await _bookRepository.UpdateBookDb(existing);
            return existing;
        }

     
        public async Task<bool> DeleteBookAsync(int bookId)
        {
            Book existing = await _bookRepository.GetBookDB(bookId);
            if (existing == null)
                throw new KeyNotFoundException("Book not found");

            await _bookRepository.DeleteBookDB(bookId);
            return true;
        }
    }
}
