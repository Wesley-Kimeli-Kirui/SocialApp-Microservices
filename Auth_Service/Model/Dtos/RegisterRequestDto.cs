using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.Model.Dtos
{
    public class RegisterRequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]

        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        //optional
        public string? Role { get; set; } = string.Empty;
    }
}