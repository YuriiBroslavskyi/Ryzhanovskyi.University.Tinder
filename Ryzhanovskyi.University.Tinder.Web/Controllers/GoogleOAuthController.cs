using Microsoft.AspNetCore.Mvc;
using Ryzhanovskiy.University.Tinder.Core.Services;


namespace Ryzhanovskiy.University.Tinder.API.Controllers
{
    public class GoogleOAuthController : Controller
    {
        public IActionResult RedirectOnOAuthServer()
        {
            var url = GoogleAuthService.GenerateOAuthRequestUrl();
            return Redirect(url);
        }

        public IActionResult Code(string code)
        {
            GoogleAuthService.ExchangeCodeOnToken(code);
            return Ok();
        }
    }
}