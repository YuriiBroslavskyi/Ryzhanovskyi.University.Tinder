using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ryzhanovskiy.University.Tinder.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var clientID = _logger["Authentication:Google:ClientID"];
            var clientSecret = _logger["Authentication:Google:ClientSecret"];
        }
    }
}