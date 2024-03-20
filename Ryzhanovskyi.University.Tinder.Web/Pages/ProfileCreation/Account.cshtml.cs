using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Models.Models;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Web.Pages.Profile
{
    public class AccountModel : PageModel
    {
        private readonly IProfileService _profileCreation;

        public AccountModel(IProfileService profileCreation)
        {
            _profileCreation = profileCreation;
        }

        [BindProperty]
        public ProfileRequestDto ProfileRequest { get; set; }
        public User User { get; private set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (User != null)
            {
                User = await _profileCreation.GetUserDetails(User.Id);

                if (User != null)
                {
                    // Redirect to the account page with user ID included in the URL
                    return RedirectToPage("/ProfileCreation/Account", new { Id = User.Id });
                }
                else
                {
                    return NotFound("User not found");
                }
            }

            // Handle the case when user is not authenticated
            return RedirectToPage("/Auth/Login");
        }
    }
}
