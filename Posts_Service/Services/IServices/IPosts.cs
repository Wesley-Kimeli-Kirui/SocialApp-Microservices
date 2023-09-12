using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Posts_Service.Models;
using Posts_Service.Models.Dtos;

namespace Posts_Service.Services.IServices
{
    public interface IPosts
    {
        Task<string> CreatePost(Posts post);
        Task<string> UpdatePost(Posts posts);
        Task<string> UpdatePostContent(Guid postId, string postContent);
        Task<PostsDto> GetPostById(Guid postId);
        Task<string> DeletePost(Guid postId);
    }
}