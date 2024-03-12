using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Models.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email adress.")]
        public string Email { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Photo {  get; set; } = string.Empty;




    }
}
