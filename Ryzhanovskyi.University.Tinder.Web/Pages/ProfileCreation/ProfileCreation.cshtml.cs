using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Core.Services;
using Ryzhanovskyi.University.Tinder.Models.Auth;
using Ryzhanovskyi.University.Tinder.Models.Models;


namespace Ryzhanovskyi.University.Tinder.Web.Pages.ProfileCreation
{
    public class ProfileCreationModel : PageModel
    {
        private readonly IProfileService _profileCreation;

        public ProfileCreationModel(IProfileService profileCreation)
        {
            _profileCreation = profileCreation;
        }

        [BindProperty]
        public ProfileRequestDto ProfileRequest { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _profileCreation.CreateProfile(ProfileRequest);

                if (result != null)
                {
                    return RedirectToPage("/ProfileCreation/ProfileCreation");
                }
                else
                {
                    return RedirectToPage("/Auth/Register");
                }
            }
            return Page();
        }
    }
}
