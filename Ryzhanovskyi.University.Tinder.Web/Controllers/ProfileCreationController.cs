using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ryzhanovskyi.University.Tinder.Web.Data;
using Ryzhanovskyi.University.Tinder.Models.Models;
using System.Threading.Tasks;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Core.Services;

namespace Ryzhanovskyi.University.Tinder.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileCreationController : ControllerBase
    {
        private readonly IProfileService _profileservice;

        public ProfileCreationController(IProfileService profileService)
        {
            _profileservice = profileService;
        }

        [HttpPost("ProfileCreation")]
        public async Task<IActionResult> CreateProfile(ProfileRequestDto request)
        {
            var profile = await _profileservice.CreateProfile(request);

            if (profile == null)
            {
                return RedirectToAction("Register", "Auth");
            }

            if (request.Gender != "Male" && request.Gender != "Female")
            {
                return BadRequest("Choose Male or Female.");
            }
            if (request.Age < 18)
            {
                return BadRequest("Your age must be at least 18.");
            }
            try
            {
                return Ok(profile);
            }
            catch (DbUpdateException)
            {
                return BadRequest("An error occurred while updating the profile.");
            }
        }

        [HttpGet("account{Id}")]
        public async Task<ActionResult<User>> GetAccountDetails(string Id)
        {
            var user = await _profileservice.GetUserDetails(Id);

            if (user == null)
            {
                return NotFound("User nor found"); 
            }

            return user;
        }
    }
}
