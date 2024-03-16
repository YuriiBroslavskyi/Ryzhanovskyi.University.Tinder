using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Models.Auth;
using Ryzhanovskyi.University.Tinder.Models.Models;
using Ryzhanovskyi.University.Tinder.Core.Services;

namespace Ryzhanovskyi.University.Tinder.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRequestDto request)
        {
            var user = await _authService.RegisterAsync(request);

            if (user == null)
            {
                return BadRequest("Email is already registered.");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserRequestDto request)
        {
            var user = await _authService.LoginAsync(request);

            if (user == null)
            {
                return BadRequest("Invalid email or password.");
            }

            return Ok(user);
        }
    }
}
