using Microsoft.EntityFrameworkCore;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Models.Auth;
using Ryzhanovskyi.University.Tinder.Models.Models;
using Ryzhanovskyi.University.Tinder.Web.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IEmailSender _emailSender;

        public AuthService(DataContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public async Task<User> RegisterAsync(UserRequestDto request)
        {
            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return null; 
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash
            };

            var welcomeEmail = new EmailModel
            {
                Email = request.Email,
                Subject = "Mail for successfully registration at GnomeLove",
                Message = $"Welcome {user.UserName} to Dating Web APP GnomeLove, good luck in searching your love ^_^"
            };
            await _emailSender.SendEmailAsync(welcomeEmail.Email, welcomeEmail.Subject, welcomeEmail.Message);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user; 
        }

        public async Task<User> LoginAsync(UserRequestLogDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
            {
                throw new SyntaxErrorException("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new SyntaxErrorException("Incorrect password.");
            }

            return user;
        }
    }
}