using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Ryzhanovskiy.University.Tinder.Core.Constants;
using Ryzhanovskiy.University.Tinder.Models.Configuration;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;


namespace Ryzhanovskiy.University.Tinder.Core.Services
{
    public class GoogleAuthService : IGoogleAuthInterface
    {
        private const string ClientId = "460055857959-jo5beonip1crjebins8rtbus4796flua.apps.googleusercontent.com";
        private const string ClientSecret = "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";

        public static string GenerateOAuthRequestUrl(string scope, string redirectUrl, string codeChellange)
        {
            var oAuthServerEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";

            var queryParams = new Dictionary<string, string>
            {
                {"client_id", ClientId},
                {"redirected_uri", redirectUrl},
                {"response_type", "code"},
                {"scope", scope },
                {"code_challenge", codeChellange },
                {"code_challenge_methode","S256"}
            };
            var url = QueryHelpers.AddQueryString(oAuthServerEndpoint, queryParams);
            return url;
        }

        public static object ExchangeCodeOnToken(string code)
        {
            throw new NotImplementedException();
        }

        public static object RefreshToken(string refreshToken)
        {
            throw new NotImplementedException();

        }
    }
}
