using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_Service.Model;
using Auth_Service.Model.Dtos;
using AutoMapper;

namespace Auth_Service.Profiles
{
    public class AuthProfiles : Profile
    {
        public AuthProfiles()
        {
            CreateMap<RegisterRequestDto, AppUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}