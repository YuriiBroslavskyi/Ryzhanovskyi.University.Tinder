using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ryzhanovskiy.University.Tinder.Web.Pages;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Models.Auth;
using Ryzhanovskyi.University.Tinder.Models.Models;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Web.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly IAuthService _authService;


        public LoginModel(ILogger<LoginModel> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [BindProperty]
        public UserRequestLogDto UserRequestLog { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = _authService.LoginAsync(UserRequestLog);

                if (result != null)
                {
                    return RedirectToPage("/privacy");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Wrong Password or Account with this email doesn't exist");
                    return Page();
                }
            }

            return Page();
        }

    }
}