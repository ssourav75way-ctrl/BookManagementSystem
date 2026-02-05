
using dotNetBasic.DTO;
using  dotNetBasic.Models;

namespace dotNetBasic.ViewModels
{
    public class BooksViewModel
    {
        public List<BooksDTO> AllBooks { get; set; } = new List<BooksDTO>();
        public string SelectedGenre { get; set; } = string.Empty;
        public List<BooksDTO> SelectedBooksGenres { get; set; } = new List<BooksDTO>();
        public int TotalBooks { get; set; }
        public List<BooksDTO> HighlightedBooks { get; set; } = new List<BooksDTO>();
    }

    public class BookDetailsModel
    {
        public int Id = 0;
        public string Title = string.Empty;
        public string Description = string.Empty;
        public string Author = string.Empty;
        public string Genre = string.Empty;
        public bool Available = false;
        public DateTime AddedOn;
    }
   
}