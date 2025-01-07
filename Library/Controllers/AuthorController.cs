using Library.Models;
using Library.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    //[Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly IRepository<Author> authorRepository;
        private readonly IRepository<Book> bookRepository;
        private readonly IRepository<Genre> genreRepository;

        public AuthorController(IRepository<Author> authorRepository, IRepository<Book> bookRepository, IRepository<Genre> genreRepository)
        {
            this.authorRepository = authorRepository;
            this.bookRepository = bookRepository;
            this.genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var authors = await authorRepository.GetAllAsync();

            foreach(var author in authors)
            {
                IEnumerable<Book> enumerable = await bookRepository.FindAsync(book => book.AuthorId == author.Id);
                author.Books = enumerable.ToList();
            }
            return View(authors);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var author = await authorRepository.GetByIdAsync(Id);
            if (author == null) throw new ArgumentException("Now existing author Id");

            return View(author);
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details(Guid Id)
        {
            var author = await authorRepository.GetByIdAsync(Id);
            if (author == null) throw new ArgumentException("Now existing author Id");

            var books = await bookRepository.FindAsync(a => a.AuthorId == author.Id);
            author.Books = books.ToList();

            var genres = await genreRepository.GetAllAsync();

            ViewBag.Genres = new SelectList(genres, "Id", "Name");

            return View(author);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            await authorRepository.UpdateAsync(author);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("BookEdit")]
        public async Task<IActionResult> BookEdit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            await bookRepository.UpdateAsync(book);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Author newAuthor)
        {
            if (!ModelState.IsValid)
            {
                return View(newAuthor);
            }
            newAuthor.Id = Guid.NewGuid();


            await authorRepository.AddAsync(newAuthor);

            return RedirectToAction(nameof(Index));
        }



        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var author = await authorRepository.GetByIdAsync(Id);
            if (author == null) throw new ArgumentException("Now existing author Id");

            await authorRepository.RemoveAsync(author);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("DeleteBook")]
        public async Task<IActionResult> DeleteBook(Guid Id)
        {
            var book = await bookRepository.GetByIdAsync(Id);
            if (book == null) throw new ArgumentException("Now existing book Id");

            await bookRepository.RemoveAsync(book);

            return RedirectToAction(nameof(Details), "Author", new { id = book.AuthorId });
        }

        [HttpGet("EditBook")]
        public async Task<IActionResult> EditBook(Guid Id)
        {
            var book = await bookRepository.GetByIdAsync(Id);
            if (book == null) throw new ArgumentException("Now existing book Id");
            book.Genre = await genreRepository.GetByIdAsync(book.GenreId);
            var genres = await genreRepository.GetAllAsync();

            ViewBag.Genres = new SelectList(genres, "Id", "Name");
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = new Guid();
                await bookRepository.AddAsync(book);

                return Json(new
                {
                    success = true,
                    book = new
                    {
                        book.Name,
                        book.Count
                    }
                });
            }

            return Json(new { success = false });
        }
    }
}
