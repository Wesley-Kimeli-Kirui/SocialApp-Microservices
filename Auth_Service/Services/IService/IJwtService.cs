using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_Service.Model;

namespace Auth_Service.Services.IService
{
    public interface IJwtService
    {
        string GenerateToken(AppUser user, IEnumerable<string> roles);
    }
}