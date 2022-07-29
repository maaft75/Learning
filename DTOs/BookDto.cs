using System.ComponentModel.DataAnnotations;

namespace bookApi.DTOs
{
    public class BookDto
    {
        [Required]
        public string Name{get; set;}
        [Required]
        public string AuthorName{get; set;}
    }
}