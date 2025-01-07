using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Author
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? SurName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
