using Microsoft.AspNetCore.Mvc;
using LibraryApplication.API.Repository;
using LibraryApplication.API.Domain.User;
using LibraryApplication.API.Service.UserService;

namespace LibraryApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _userService.AddUser(user);
            return Ok(await _userService.GetUsers());
        }

        [HttpPut("{id}")]
         public async Task<IActionResult> PutUser(Guid id, User user)
         {
            await _userService.UpdateUser(id, user);
            return Ok(await _userService.GetUserById(id));
         }

         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteUser(Guid id)
         {
             await _userService.DeleteUser(id);
            return Ok(await _userService.GetUsers());
         }
    }
}
