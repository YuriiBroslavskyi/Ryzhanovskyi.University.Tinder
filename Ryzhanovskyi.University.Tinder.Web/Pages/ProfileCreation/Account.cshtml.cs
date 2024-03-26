using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskyi.University.Tinder.Models.Models;
using Ryzhanovskyi.University.Tinder.Web.Data;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Web.Pages
{
    public class UserProfileModel : PageModel
    {
        private readonly DataContext _context;

        public UserProfileModel(DataContext context)
        {
            _context = context;
        }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = _context.Users.ToList();
        }
    }
}

