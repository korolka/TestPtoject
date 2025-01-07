using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Count { get; set; }
        public Guid AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author? Author {  get; set; }
        [Required]
        public Guid GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
    }
}