using IdentityModel;
using System.Security.Cryptography;
using System.Text;

namespace Ryzhanovskyi.University.Tinder.Core.Services
{
    public static class Sha256code
    {
        public static string ComputeHash(string codeVerifier)
        {
            using var sha256 = SHA256.Create();
            var challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));
            var codeChallenge = Base64Url.Encode(challengeBytes);
            return codeChallenge;
        }
    }
}
