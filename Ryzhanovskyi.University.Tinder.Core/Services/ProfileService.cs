using Microsoft.Exchange.WebServices.Data;
using Microsoft.AspNetCore.Mvc;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Models.Models;
using Ryzhanovskyi.University.Tinder.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ryzhanovskyi.University.Tinder.Core.Services
{
    public class ProfileService : IProfileService
    {
        private readonly DataContext _context;
        public ProfileService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> CreateProfile(ProfileRequestDto request)
        {
            var profile = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (profile == null)
            {
                return null;
            }

            if (request.Gender != "Male" && request.Gender != "Female")
            {
                return null;
            }
            profile.Gender = request.Gender;

            if (request.Age < 18)
            {
                return null;
            }

            profile.Age = request.Age;


            profile.UserName = request.Username;
            profile.Email = request.Email;
            profile.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            profile.City = request.City;
            profile.Description = request.Description;
            profile.Photo = request.Photo;


            await _context.SaveChangesAsync();
            return profile;
        }
    }
}
