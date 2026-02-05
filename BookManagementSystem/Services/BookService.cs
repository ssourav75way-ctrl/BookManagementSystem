using dotNetBasic.Data;
using dotNetBasic.DTO;
using dotNetBasic.Models;
using dotNetBasic.Models;
using Microsoft.AspNetCore.Http.HttpResults;

public class BookService : IBookService
{
   public static BooksDTO MapToBookDTO(Book book)
   {
      return new BooksDTO
      {
         Id = book.Id,
         Author = book.Author,
         Title = book.Title,
         Genre = book.Genre,
         AddedOn = book.AddedOn,
         Description = book.Description,

      };
   }
   public List<BooksDTO> GetAllBooks()
   {
      
      return BookData.Books.Select(MapToBookDTO).ToList();
   }

   public List<BooksDTO> GetBookByGenre(string genre)
   {
      return BookData.Books.Select(MapToBookDTO)
         .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
         .ToList();
   }

   public BooksDTO? GetBookDetails(int id)
   {
      return BookData.Books.Select(MapToBookDTO).FirstOrDefault(b => b.Id == id);
   }

   public List<BooksDTO> GetHighlightBooks()
   {
      return BookData.Books.Select(MapToBookDTO)
         .Where(b => b.AddedOn >= DateTime.Now.AddDays(-3))
         .ToList();

   }

   
  
}