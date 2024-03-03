using Microsoft.AspNetCore.Mvc;
using Ryzhanovskiy.University.Tinder.Core.Services;
using Ryzhanovskyi.University.Tinder.Core.Services;
using System.Security.Cryptography;


namespace Ryzhanovskiy.University.Tinder.API.Controllers
{
    public class GoogleOAuthController : Controller
    {
        public IActionResult RedirectOnOAuthServer()
        {
            var scope = "https://www.googleapis.com/auth/userinfo.email\t";
            var redirectUrl = "/GoogleOAuth/Code";

            var codeVerify = Guid.NewGuid().ToString();
            var codeChallenge = Sha256code.ComputeHash(codeVerify);
            var url = GoogleAuthService.GenerateOAuthRequestUrl(scope, redirectUrl, codeChallenge);
            return Redirect(url);
        }

        public IActionResult Code(string code)
        {
            GoogleAuthService.ExchangeCodeOnToken(code);
            return Ok();                                                                                                    
        }
    }
}