using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_Service.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth_Service.Data
{
    public class AuthDbContext : IdentityDbContext<AppUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}