using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Comments_Service.Entities;
using Comments_Service.Entities.Dtos;

namespace Comments_Service.Profiles
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile()
        {
            CreateMap<Comment, CommentsDto>().ReverseMap();
            CreateMap<Comment, PostCommentDto>().ReverseMap();
        }
    }
}