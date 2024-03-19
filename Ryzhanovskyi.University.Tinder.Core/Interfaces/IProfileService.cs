using Microsoft.AspNetCore.Mvc;
using Ryzhanovskyi.University.Tinder.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Core.Interfaces
{
    public interface IProfileService
    {
        Task<User> CreateProfile(ProfileRequestDto request);
    }

}
