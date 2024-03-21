using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Models.Auth;
using Ryzhanovskyi.University.Tinder.Models.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace Ryzhanovskyi.University.Tinder.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserRequestDto request)
        {
            var user = await _authService.RegisterAsync(request);

            if (user == null)
            {
                return BadRequest("Email is already registered.");
            }

            return Ok(user);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserRequestLogDto request)
        {
            var User = await _authService.LoginAsync(request);

            if (User != null) {

                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, User.UserName)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
                return Ok(User);
            }
            else
            {
                return RedirectToPage("/Auth/Register");
            }
        } 
         
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}