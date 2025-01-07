using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Genre
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}