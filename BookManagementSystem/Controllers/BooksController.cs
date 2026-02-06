using dotNetBasic.Interfaces;
using dotNetBasic.DTO;
using dotNetBasic.Models;
using Microsoft.AspNetCore.Mvc;
using dotNetBasic.ViewModels;

namespace dotNetBasic.Controllers
{
    [Route("/")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            try
            {
                List <BooksDTO> books = await _bookService.GetAllBooks();
                List<BooksDTO> highlightedBooks = await _bookService.GetHighlightBooks();

                BooksViewModel booksModel = new ViewModels.BooksViewModel
                {
                    AllBooks = books,
                    HighlightedBooks = highlightedBooks,
                    TotalBooks = books.Count
                };

                return View(booksModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            BooksDTO  book = await _bookService.GetBookDetails(id);
            if (book == null)
                return BadRequest("Book Not Found!");

            return View(book);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            BooksDTO book = await _bookService.GetBookDetails(id);
            if (book == null) return BadRequest("Book not Found!");
            return Json(book);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] createBookDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data");

            Book book = new Book
            {
                Title = dto.Title,
                Description = dto.Description,
                Author = dto.Author,
                Genre = dto.Genre,
                AddedOn = DateTime.UtcNow,
                isAvailable = true,
                Createdby = "admin"
            };

            await _bookService.AddBookAsync(book);
            return Ok(new { id = book.Id, title = book.Title });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateBookDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data");

            try
            {
                await _bookService.UpdateBookAsync(dto);
                return Ok(new { success = true });
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Book not found");
            }
        }

        [HttpGet("GetByGenre/{genre}")]
        public async Task<IActionResult> GetByGenre(string genre)
        {
            try
            {
                if (string.IsNullOrEmpty(genre))
                {
                    var allBooks = await _bookService.GetAllBooks();
                    return Json(allBooks);
                }

                List<BooksDTO> books = await _bookService.GetBookByGenre(genre);
                return Json(books);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error fetching books", error = ex.Message });
            }
        }

        [HttpGet("GetGenres")]
        public async Task<IActionResult> GetGenres()
        {
            try
            {
                List<string> genres = await _bookService.GetAllGenres();
                return Json(genres);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error fetching genres", error = ex.Message });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool success = await _bookService.DeleteBookAsync(id);
            if (!success) return BadRequest("Delete failed");
            return Ok(id);
        }

        [HttpGet("Highlight")]
        public async Task<IActionResult> Highlight()
        {
            List<BooksDTO> highlightedBooks = await _bookService.GetHighlightBooks();
            return Json(highlightedBooks);
        }
    }
}
