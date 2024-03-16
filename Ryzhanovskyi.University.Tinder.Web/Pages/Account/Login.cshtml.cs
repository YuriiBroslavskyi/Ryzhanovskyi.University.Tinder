using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ryzhanovskyi.University.Tinder.Models.Auth;

namespace Ryzhanovskyi.University.Tinder.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public UserRequestDto UserRequest { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Wrong password.");
            }

        
            return RedirectToPage("/Index");
        }
    }
}
