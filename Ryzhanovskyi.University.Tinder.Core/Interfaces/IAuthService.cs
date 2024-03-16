using Ryzhanovskyi.University.Tinder.Models.Auth;
using Ryzhanovskyi.University.Tinder.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Core.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(UserRequestDto request);
        Task<User> LoginAsync(UserRequestLogDto request);
    }
}
