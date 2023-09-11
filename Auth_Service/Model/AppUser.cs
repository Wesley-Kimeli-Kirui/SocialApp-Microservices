using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Auth_Service.Model
{
    public class AppUser : IdentityUser
    {
        // you can add more properties here
        public string Name { get; set; } = string.Empty;
    }
}