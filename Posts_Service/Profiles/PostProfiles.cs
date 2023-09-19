using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Posts_Service.Models;
using Posts_Service.Models.Dtos;

namespace Posts_Service.Profiles
{
    public class PostProfiles : Profile
    {
        public PostProfiles()
        {
            CreateMap<Posts, PostsDto>().ReverseMap();
            // CreateMap<Models.Dtos.PostsDto, Models.Posts>();
            CreateMap<ResponseDto, ResponseDto>().ReverseMap();
        }
    }
}