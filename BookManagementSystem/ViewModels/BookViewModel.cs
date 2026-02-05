
using dotNetBasic.DTO;
using  dotNetBasic.Models;

namespace dotNetBasic.ViewModels
{
    public class BooksViewModel
    {
        public List<BooksDTO> AllBooks { get; set; } = new List<BooksDTO>();
        public int TotalBooks { get; set; }
        public List<BooksDTO> HighlightedBooks { get; set; } = new List<BooksDTO>();
    }
   
}