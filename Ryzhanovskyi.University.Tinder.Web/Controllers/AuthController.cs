using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ryzhanovskyi.University.Tinder.Models.Models;

namespace Ryzhanovskyi.University.Tinder.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        [HttpPost("register")]

        public ActionResult<User> Register(UserRequestDto request)
        {
            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password);
            
            user.UserName = request.Username;
            user.Email = request.Email;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }
        [HttpPost("login")]

        public ActionResult<User> Login(UserRequestDto request)
        {
            if(user.Email != request.Email)
            {
                return BadRequest("User not Found");
            }

            if(!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong Password");
            }

            return Ok(user);
        }
    }
}
