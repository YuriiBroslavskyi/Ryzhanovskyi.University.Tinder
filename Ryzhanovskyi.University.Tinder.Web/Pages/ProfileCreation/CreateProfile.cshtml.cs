using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Models.Models;

namespace Ryzhanovskyi.University.Tinder.Web.Pages.ProfileCreation
{
    public class ProfileCreationModel : PageModel
    {
        private readonly IProfileService _profileService;

        public ProfileCreationModel(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [BindProperty]
        public ProfileRequestDto ProfileRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _profileService.CreateProfile(ProfileRequest);

                if (result != null)
                {
                    return RedirectToPage("/ProfileCreation/Account");
                }
                else
                {
                    return BadRequest("/Error");
                }
            }
            return Page();
        }
    }
}
