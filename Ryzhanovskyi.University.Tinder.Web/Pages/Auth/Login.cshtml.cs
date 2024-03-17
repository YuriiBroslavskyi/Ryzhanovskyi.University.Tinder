using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Models.Auth;

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginAsync(UserRequestLog);

                if (result != null)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    return BadRequest("Wrong Password or Account with this email doesn`t exist");
                }
            }

            return Page();
        }
    }
}
