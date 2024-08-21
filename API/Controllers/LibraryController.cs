using LibraryApplication.API.Domain.Book;
using LibraryApplication.API.Domain.User;
using LibraryApplication.API.Service.LibraryService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.API.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private LibraryService _libraryService;

        public LibraryController(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetRentBooks()
        {
            return await _libraryService.GetRentBooks();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book?>> GetRentBookById(Guid id)
        {
            return await _libraryService.GetRentBookById(id);
        }

        [HttpPost("{idBook}/{IdUser}/{daysRent}")]
        public async Task RentABook(Guid idBook, Guid IdUser, int daysRent)
        {
            await _libraryService.RentBook(idBook, IdUser, daysRent);
        }

        [HttpGet("get-user-from-book-id/{id}")]
        public async Task<ActionResult<User?>> GetWhoRendTheBook(Guid id)
        {
            return await _libraryService.GetUserRentedBook(id);
        }

    }
}
