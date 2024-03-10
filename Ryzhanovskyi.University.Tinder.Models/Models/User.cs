using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Models.Models
{
    public class User : IdentityUser
    {
        public string UserName { get; set; } = string.Empty;
/*        public string Email { get; set; } = string.Empty;*/
        public string PasswordHash { get; set; } = string.Empty;

    }
}
