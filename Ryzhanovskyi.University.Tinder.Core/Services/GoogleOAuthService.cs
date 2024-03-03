using Microsoft.Extensions.Options;
using Ryzhanovskiy.University.Tinder.Core.Constants;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskiy.University.Tinder.Models.Configuration;


namespace Ryzhanovskiy.University.Tinder.Core.Services
{
    public class GoogleAuthService : IGoogleAuthInterface
    {
        private const string ClientId = "460055857959-jo5beonip1crjebins8rtbus4796flua.apps.googleusercontent.com";
        private const string ClientSecret = "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";
    }
}
