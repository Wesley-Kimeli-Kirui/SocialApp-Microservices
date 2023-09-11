using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_Service.Model.Dtos;

namespace Auth_Service.Services.IService
{
    public interface IUserInterface
    {
        Task<string> RegisterUser(RegisterRequestDto registerRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignUserRole(string email, string Rolename);
    }
}