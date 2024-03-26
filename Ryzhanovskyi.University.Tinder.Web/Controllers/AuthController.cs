using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Models.Auth;
using Ryzhanovskyi.University.Tinder.Models.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Ryzhanovskyi.University.Tinder.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Register(UserRequestDto request)
        {
            var user = await _authService.RegisterAsync(request);

            if (user == null)
            {
                return BadRequest("Email is already registered.");
            }

            await AuthenticateAsync(user);
            return RedirectToAction("Index");
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Login(UserRequestLogDto request)
        {
            var user = await _authService.LoginAsync(request);

            if (user != null) {

                await AuthenticateAsync(user);
                return Ok(user);
            }
            else
            {
                return RedirectToPage("/Auth/Register");
            }
        }
        public async Task AuthenticateAsync(User user)
        {
            var claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
        }

        public  async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage(".../Index");
        }
    }
}