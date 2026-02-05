using System.ComponentModel.DataAnnotations;

namespace dotNetBasic.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required] [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required][MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required] [MaxLength(50)] public string Author { get; set; } = string.Empty;
        [Required]  [MaxLength(50)] public string Genre { get; set; } = string.Empty;
        public bool Available { get; set; } = true;
        [Required] 
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
    }
}