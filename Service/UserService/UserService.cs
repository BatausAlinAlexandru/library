using LibraryApplication.API.Domain.User;
using LibraryApplication.API.Repository;

namespace LibraryApplication.API.Service.UserService
{
    public class UserService : IUserService
    {
        private UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task AddUser(User user)
        {
            UserValidator.ValidateUserName(user.Username);
            UserValidator.ValidatePassword(user.Password);
            UserValidator.ValidateEmail(user.Email);

            await _repository.AddUserAsync(user);
        }

        public async Task UpdateUser(Guid guid, User newUser)
        {
            // VALIDATE THE NEW USER
            UserValidator.ValidateUserName(newUser.Username);
            UserValidator.ValidatePassword(newUser.Password);
            UserValidator.ValidateEmail(newUser.Email);


            Task<User?> OldUser = _repository.GetUserByIdAsync(guid);
            if (OldUser.Result != null)
            {
                OldUser.Result.Username = newUser.Username;
                OldUser.Result.Password = newUser.Password;
                OldUser.Result.Email = newUser.Email;

                await _repository.UpdateUserAsync(OldUser.Result);
            }
        }

        public async Task<List<User>> GetUsers()
        {
            return await _repository.GetUsersAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        { 
            return await _repository.GetUserByIdAsync(id);
        }

        public async Task DeleteUser(Guid id)
        {
            await _repository.DeleteUserAsync(id);
        }
    }
}
