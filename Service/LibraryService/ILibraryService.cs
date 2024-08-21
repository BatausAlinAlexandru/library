using LibraryApplication.API.Domain.Book;
using LibraryApplication.API.Domain.User;

namespace LibraryApplication.API.Service.LibraryService
{
    public interface ILibraryService
    {
        
        // BOOK OPERATIONS
        Task<List<Book>> GetRentBooks();
        Task<Book?> GetRentBookById(Guid id);

        // USER OPERATIONS
        Task<User?> GetUserRentedBook(Guid id);
        
        Task RentBook(Guid idBook, Guid idUser, int daysRent);
        
    }
}
