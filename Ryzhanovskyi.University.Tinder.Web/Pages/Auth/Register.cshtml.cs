using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Core.Services;
using Ryzhanovskyi.University.Tinder.Models.Auth;
using Ryzhanovskyi.University.Tinder.Models.Models;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Web.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly IAuthService _authService;

        public RegisterModel(IAuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public UserRequestDto UserRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterAsync(UserRequest);

                if (result != null)
                {
                    return RedirectToPage("/ProfileCreation/CreationProfile");
                }
                else
                {
                    return BadRequest("Try antoher mail");
                }
            }

            return Page();
        }
    }
}
