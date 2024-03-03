using Microsoft.Extensions.Options;
using Ryzhanovskiy.University.Tinder.Core.Constants;
using Ryzhanovskiy.University.Tinder.Models.Configuration;
using System.Security.Cryptography.X509Certificates;


namespace Ryzhanovskiy.University.Tinder.Core.Services
{
    public class GoogleAuthService
    {
        private const string ClientId = "460055857959-jo5beonip1crjebins8rtbus4796flua.apps.googleusercontent.com";
        private const string ClientSecret = "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";

        public static string GenerateOAuthRequestUrl()
        {

        }

        public static object ExchangeCodeOnToken(string code)
        {

        }

        public static object RefreshToken(string refreshToken)
        {

        }
    }
}
