using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ryzhanovskyi.University.Tinder.Core.Interfaces;
using Ryzhanovskiy.University.Tinder.Core.Services;
using Ryzhanovskiy.University.Tinder.Models.Configuration;

namespace Ryzhanovskiy.University.Tinder.Core
{
    public static class DIConfiguration
    {
        public static void RegisterCoreDependencies(this IServiceCollection services)
        {
            services.AddTransient<IGoogleAuthInterface, GoogleAuthService>();
        }

        public static void RegisterCoreConfiguration(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AppConfig>(configuration.GetSection("AppConfig"));
        }
    }
}

