using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Posts_Service.Data;
using Posts_Service.Models;
using Posts_Service.Models.Dtos;
using Posts_Service.Services.IServices;

namespace Posts_Service.Services
{
    public class PostService : IPosts
    {
        private readonly PostsDbContext _db;
        private readonly IMapper _mapper;
        public PostService(PostsDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<string> CreatePost(Posts posts)
        {
            _db.Posts.Add(posts);
            _db.SaveChanges();
            return "Post created successfully";

        }

        public Task<string> DeletePost(Guid postId)
        {
            _db.Posts.Remove(_db.Posts.Find(postId));
            _db.SaveChanges();
            return Task.FromResult("Post deleted successfully");
        }

        public Task<PostsDto> GetPostById(Guid postId)
        {
            _db.Posts.Where(x => x.PostId == postId).FirstOrDefault();
            return Task.FromResult(new PostsDto());
        }

        public Task<string> UpdatePost(Posts posts)
        {
            _db.Posts.Update(posts);
            _db.SaveChanges();
            return Task.FromResult("Post updated successfully");
        }

        public Task<string> UpdatePostContent(Guid postId, string postContent)
        {
            _db.Posts.Find(postId).PostContent = postContent;
            _db.SaveChanges();
            return Task.FromResult("Post content updated successfully");
        }
    }
}