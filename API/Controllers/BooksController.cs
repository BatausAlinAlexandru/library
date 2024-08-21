using Microsoft.AspNetCore.Mvc;
using LibraryApplication.API.Repository;
using LibraryApplication.API.Domain.Book;
using LibraryApplication.API.Domain.User;
using LibraryApplication.API.Service.BookService;

namespace LibraryApplication.API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookService _bookService;


        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _bookService.GetBooks();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(Guid id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PutBook(Book book)
        {
            await _bookService.AddBook(book);
            return Ok(await _bookService.GetBooks());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, Book user)
        {
           await _bookService.Updatebook(id, user);
            return Ok(await _bookService.GetBookById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _bookService.DeleteBook(id);
            return Ok(await _bookService.GetBooks());
        }
    }
}
