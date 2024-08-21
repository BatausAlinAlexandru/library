using LibraryApplication.API.Domain.User;

namespace LibraryApplication.API.Service.UserService
{
    public interface IUserService
    {
        public Task AddUser(User user);
        public Task UpdateUser(Guid guid, User NewUser);
        public Task DeleteUser(Guid guid);

        public Task<List<User>> GetUsers();
        public Task<User?> GetUserById(Guid id);
    }
}
