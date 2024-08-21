using LibraryApplication.API.Domain.Book;
using LibraryApplication.API.Repository;

namespace LibraryApplication.API.Service.BookService
{
    public class BookService
    {
        private BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task AddBook(Book book)
        {
            BookValidator.ValidateTitle(book.Title);
            BookValidator.ValidateAuthor(book.Author);
            //BookValidator.ValidateISBN(book.ISBN); NU FACEM ASTA MOMENTAN CA E JALE 
            BookValidator.ValidatePrice(book.Price);
            await _bookRepository.AddBookAsync(book);
        }

        public async Task Updatebook(Guid guid, Book book)
        {
            Task<Book> OldBook = _bookRepository.GetBookByIdAsync(guid);
           
            if (OldBook != null)
            {
                OldBook.Result.Title = book.Title;
                OldBook.Result.Author = book.Author;
                OldBook.Result.ISBN = book.ISBN;
                OldBook.Result.Price = book.Price;

                OldBook.Result.IsRent = book.IsRent;
                OldBook.Result.DateStartRent = book.DateStartRent;
                OldBook.Result.DaysRent = book.DaysRent;
                OldBook.Result.DateStopRent = book.DateStopRent;

                await _bookRepository.UpdateBookAsync(OldBook.Result);
            }
        }

        public async Task UPDATE(Book book)
        {
            await _bookRepository.UpdateBookAsync(book);
        }


        public async Task DeleteBook(Guid id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _bookRepository.GetBooksAsync();
        }

        public async Task<Book?> GetBookById(Guid id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

    }
}
