using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Ryzhanovskyi.University.Tinder.Models.Models;
using Ryzhanovskyi.University.Tinder.Web.Data;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Core.Services;

namespace Ryzhanovskyi.University.Tinder.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IEmailSender _emailSender;


        public AuthController(DataContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRequestDto request)
        {

            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return BadRequest("Email is already registered.");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash
            };

            var welcomeEmail = new EmailModel
            { Email = request.Email,
              Subject = "Mail for succesfully registration at GnomeLove",
              Message = $"Welcome {user.UserName} to Dating Web APP GnomeLove, good luck in searching ur love ^_^"
            };
            await _emailSender.SendEmailAsync(welcomeEmail.Email, welcomeEmail.Subject, welcomeEmail.Message);


            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserRequestDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            return Ok(user);
        }
    }
}
