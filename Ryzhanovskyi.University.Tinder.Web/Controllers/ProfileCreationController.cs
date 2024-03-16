using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ryzhanovskyi.University.Tinder.Web.Data;
using Ryzhanovskyi.University.Tinder.Models.Models;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileCreationController : ControllerBase
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
                return RedirectToAction("Register", "Auth");

            }

            if (request.Gender != "Male" && request.Gender != "Female")
            {
                return BadRequest("Choose Male or Female.");
            }
            profile.Gender = request.Gender;

            if (request.Age < 18)
            {
                return BadRequest("Your age must be at least 18.");
            }
            profile.Age = request.Age;

            profile.UserName = request.Username;
            profile.Email = request.Email;
            profile.PasswordHash = request.Password;
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
                return BadRequest("An error occurred while updating the profile.");
            }
        }
    }
}
