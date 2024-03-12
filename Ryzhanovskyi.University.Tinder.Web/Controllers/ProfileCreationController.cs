using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ryzhanovskyi.University.Tinder.Web.Data;
using Ryzhanovskyi.University.Tinder.Models.Models;
using Azure.Core;


namespace Ryzhanovskyi.University.Tinder.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileCreationController : Controller
    {
        private readonly DataContext _context;

        public ProfileCreationController(DataContext context)
        {

            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> CreateProfile(ProfileRequestDto request)
        {
            var profile = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (profile == null)
            {
                return NotFound();
            }

            profile.UserName = request.Username;
            profile.Email = request.Email;
            profile.PasswordHash = request.Password;
            profile.Gender = request.Gender;
            profile.Age = request.Age;
            profile.City = request.City;
            profile.Description = request.Description;
            profile.Photo = request.Photo;
                
            try
            {
                await _context.SaveChangesAsync();
                return Ok(profile);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "An error occurred while updating the profile.");
            }
        }
    }
}
