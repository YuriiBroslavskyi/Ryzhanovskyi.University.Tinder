using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Models.Auth;
using Ryzhanovskyi.University.Tinder.Models.Models;

namespace Ryzhanovskyi.University.Tinder.Web.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;

        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public UserRequestLogDto UserRequestLog { get; set; }
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                User = await _authService.LoginAsync(UserRequestLog); 

                if (User != null)
                {
                    return RedirectToAction("GetAccountDetails", "ProfileCreation", new { Id = User.Id });
                }
                else
                {
                    return BadRequest("Wrong Password or Account with this email doesn't exist");
                }
            }

            return Page();
        }
    }
}

