using LibraryApplication.API.Domain.Book;
using LibraryApplication.API.Domain.User;

namespace LibraryApplication.API.Service.LibraryService
{
    public class LibraryService : ILibraryService
    {
        private BookService.BookService _bookService;
        private UserService.UserService _userService;

        public LibraryService(BookService.BookService bookService, UserService.UserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }

        public async Task<List<Book>> GetRentBooks()
        {
            List<Book> rentedBooks = new List<Book>();
            List<Book> books = await _bookService.GetBooks();

            foreach (Book book in books)
            {
                if (book.IsRent == true) { 
                    rentedBooks.Add(book);
                }
            }
            return rentedBooks;
        }

        public async Task<Book?> GetRentBookById(Guid id)
        {
            List<Book> rentBooks = await GetRentBooks();
            foreach (Book book in rentBooks)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }



        public async Task<User?> GetUserRentedBook(Guid id)
        {
            var book = await _bookService.GetBookById(id);
            if (book != null) { 
                return await _userService.GetUserById(book.UserId.Value);
            }
            return null;
        }


        public async Task RentBook(Guid idBook, Guid idUser, int daysRent)
        {
            var book = await _bookService.GetBookById(idBook);
            var user = await _userService.GetUserById(idUser);

            if ((book != null && user != null) && (book.IsRent == false))
            {
                // INFO RENT USER
                book.UserId = user.Id; 

                // INFO RENT TIME
                book.IsRent = true;
                book.DaysRent = daysRent;
                book.DateStartRent = DateOnly.FromDateTime(DateTime.Now);
                book.DateStopRent = book.DateStartRent.AddDays(daysRent);

                // UPDATE RENTED BOOK
                await _bookService.Updatebook(book.Id, book);
            }
            else if (book.IsRent == true)
            {
                throw new InvalidOperationException("Book already rented");
            }
            else
            {
                throw new InvalidOperationException("No found book or user");
            }
        }
    }
}
