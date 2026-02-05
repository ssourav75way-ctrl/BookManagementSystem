namespace dotNetBasic.DTO;
public class BooksDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;   
    
        

        public string Description { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public bool Available { get; set; } = true;

        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
    
}