using LibraryApplication.API.Domain.Book;

namespace LibraryApplication.API.Service.BookService;

public interface IBookService
{
    Task AddBook(Book book);
    Task UpdateBook(Guid guid, Book book);
    Task DeleteBook(Guid guid);

    Task<List<Book>> GetBooks();
    Task<Book> GetBookById(Guid id);
}