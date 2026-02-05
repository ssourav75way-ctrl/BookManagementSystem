using dotNetBasic.Data;
using dotNetBasic.Interfaces;
using dotNetBasic.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetBasic.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Book>> GetAllBooksDB()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book?> GetBookDB(int bookId)
        {
            return await _dbContext.Books.FindAsync(bookId);
        }

        public async Task<List<Book>> GetBooksByGenreDB(string genre)
        {
            return await _dbContext.Books
                .Where(b => b.Genre == genre)
                .ToListAsync();
        }

        public async Task AddBookDB(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBookDb(Book book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookDB(int bookId)
        {
            var book = await _dbContext.Books.FindAsync(bookId);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<Book>> GetHighlightBooksDB()
        {
            var threeDaysAgo = DateTime.UtcNow.AddDays(-3);

            return await _dbContext.Books
                .Where(b => b.AddedOn >= threeDaysAgo)
                .OrderByDescending(b => b.AddedOn)
                .ToListAsync();
        }
    }
}