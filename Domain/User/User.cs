using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApplication.API.Domain.User
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User()
        {
          
        }

        public User(string username, string password, string email)
        {
            Id = Guid.NewGuid(); 
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
