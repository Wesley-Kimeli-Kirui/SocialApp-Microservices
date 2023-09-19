using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comments_Service.Entities;

namespace Comments_Service.Services.IService
{
    public interface IComments
    {
        Task<string> CreateComments(Comment CommentsDto);

        Task<Comment> GetComments(string userId);

        Task<string> UpdateComments(Comment CommentsDto);

        Task<string> DeleteComments(Comment Comment);
        Task<List<Comment>> GetPostComments(string postId);
        Task<List<Comment>> GetAllComments();
    }
}