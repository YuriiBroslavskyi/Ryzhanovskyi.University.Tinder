using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ryzhanovskyi.University.Tinder.Web.Data;
using Ryzhanovskyi.University.Tinder.Models.Models;
using System.Threading.Tasks;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace Ryzhanovskyi.University.Tinder.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]


    public class ProfileCreationController : ControllerBase
    {
        private readonly IProfileService _profileservice;

        public ProfileCreationController(IProfileService profileservice)
        {
            _profileservice = profileservice;
        }

        [HttpPost("CreateProfile/{Id}")]

        public async Task<IActionResult> CreateProfile(ProfileRequestDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _profileservice.CreateProfile(request);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create profile. Please check your input data.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpGet("Account/{Id}")]
        [Authorize]

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
