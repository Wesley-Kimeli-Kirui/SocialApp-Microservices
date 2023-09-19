using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comments_Service.Entities;
using Comments_Service.Services.IService;

namespace Comments_Service.Services
{
    public class CommentService : IComments
    {

        public Task<string> CreateComments(Comment CommentsDto)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteComments(Comment Comment)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetAllComments()
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetComments(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Comment>> GetPostComments(string postId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateComments(Comment CommentsDto)
        {
            throw new NotImplementedException();
        }
    }
}