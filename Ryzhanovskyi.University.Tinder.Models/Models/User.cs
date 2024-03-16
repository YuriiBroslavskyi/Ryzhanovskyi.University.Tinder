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
        public override string UserName { get; set; } = string.Empty;
        [Required]
        public override string PasswordHash { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email adress.")]
        public override string Email { get; set; } = string.Empty;
        public int Age { get; set; } = 18;
        public string Gender { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Photo {  get; set; } = string.Empty;




    }

}
