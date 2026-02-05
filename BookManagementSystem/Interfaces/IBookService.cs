using dotNetBasic.DTO;
using dotNetBasic.Models;
public interface IBookService
{
    List<BooksDTO>GetAllBooks();
    List<BooksDTO>GetBookByGenre(string genre);
    BooksDTO? GetBookDetails(int id);
    List<BooksDTO> GetHighlightBooks();
}