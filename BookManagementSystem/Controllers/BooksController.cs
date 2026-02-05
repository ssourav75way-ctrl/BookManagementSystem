using dotNetBasic.Interfaces;
using dotNetBasic.DTO;
using dotNetBasic.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNetBasic.Controllers
{
    [Route("Books")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(string genre)
        {
            try
            {
                var books = string.IsNullOrEmpty(genre)
                    ? await _bookService.GetAllBooks()
                    : await _bookService.GetBookByGenre(genre);

                var highlightedBooks = await _bookService.GetHighlightBooks();

                var booksModel = new ViewModels.BooksViewModel
                {
                    AllBooks = books,
                    HighlightedBooks = highlightedBooks,
                    TotalBooks = books.Count,
                    SelectedGenre = genre
                };

                return View(booksModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetBookDetails(id);
            if (book == null) return NotFound();
            return Json(book);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] createBookDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data");

            var book = new Book
            {
                Title = dto.Title,
                Description = dto.Description,
                Author = dto.Author,
                Genre = dto.Genre,
                AddedOn = DateTime.UtcNow,
                isAvailable = true
            };

            await _bookService.AddBookAsync(book);

            var createdBookDTO = new DTO.BooksDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Genre = book.Genre,
                AddedOn = book.AddedOn
            };

            return Ok(createdBookDTO);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateBookDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data");

            var existingBook = await _bookService.GetBookDetails(dto.Id);
            if (existingBook == null) return NotFound("Book not found");

            var book = new Book
            {
                Id =dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Author = dto.Author,
                Genre = dto.Genre,
                AddedOn = existingBook.AddedOn,
                isAvailable = existingBook.isAvailable
            };

            var success = await _bookService.UpdateBookAsync(book);
            if (!success) return BadRequest("Update failed");

            return Ok(book);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _bookService.DeleteBookAsync(id);
            if (!success) return BadRequest("Delete failed");
            return Ok(id);
        }

        [HttpGet("Highlight")]
        public async Task<IActionResult> Highlight()
        {
            var highlightedBooks = await _bookService.GetHighlightBooks();
            return Json(highlightedBooks);
        }
    }
}
