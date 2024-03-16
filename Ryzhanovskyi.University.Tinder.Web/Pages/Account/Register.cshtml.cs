using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ryzhanovskyi.University.Tinder.Models.Models;
using Ryzhanovskyi.University.Tinder.Web.Controllers;

namespace Ryzhanovskyi.University.Tinder.Web.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
