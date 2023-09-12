using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Posts_Service.Models;

namespace Posts_Service.Data
{
    public class PostsDbContext : DbContext
    {
        public PostsDbContext(DbContextOptions<PostsDbContext> options) : base(options) { }

        public DbSet<Posts> Posts { get; set; } = null!;
    }
}