using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryzhanovskyi.University.Tinder.Models.Models
{
    public class ProfileRequestDto
    {
        public string Id { get; set; }
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email adress.")]
        public required string Email { get; set; } = string.Empty;

        public required int Age { get; set; }

        public required string Gender { get; set; }

        public required string City {  get; set; } 

        public required string Description { get; set; } 

        public required string Photo { get; set; } 

    }
}
