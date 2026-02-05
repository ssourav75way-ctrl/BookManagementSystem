
using dotNetBasic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dotNetBasic.Controllers;
public class BooksController:Controller
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult Index(string genre)
    {
        try
        {
            var books = string.IsNullOrEmpty(genre)
                ? _bookService.GetAllBooks()
                : _bookService.GetBookByGenre(genre);
            var highlightedBooks = _bookService.GetHighlightBooks();
            var booksmodel = new BooksViewModel
            {
                AllBooks = books,
                HighlightedBooks = highlightedBooks,
                TotalBooks = books.Count,
                SelectedGenre = genre,
                SelectedBooksGenres = books
            };
          
         
            return View(booksmodel);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    public IActionResult Details(int id)
    {

        try
        {
            var book = _bookService.GetBookDetails(id);
            if (book == null)
            {
                return BadRequest("Book not found");
            }
            var model = new BookDetailsModel
            {
                Id= book.Id,
                Title= book.Title,
                Description= book.Description,
                Author= book.Author,
                Genre =  book.Genre,
                Available = book.Available,
                AddedOn= book.AddedOn,
            };
                

           

            return View(model);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

}