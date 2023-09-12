using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Posts_Service.Profiles
{
    public class PostProfiles : Profile
    {
        public PostProfiles()
        {
            CreateMap<Models.Posts, Models.Dtos.PostsDto>();
            CreateMap<Models.Dtos.PostsDto, Models.Posts>();
            CreateMap<Models.Dtos.ResponseDto, Models.Dtos.ResponseDto>();
        }
    }
}