using System.ComponentModel.DataAnnotations;

namespace bookApi.Models
{
    public class Book
    {
        [Key]
        public int Id{get; set;}
        [Required]
        public string Name{get; set;}
        [Required]
        public string AuthorName{get; set;}
        [Required]
        public DateTime DateCreated{get; set;}
        [Required]
        public DateTime DateUpdated{get; set;}
    }
}