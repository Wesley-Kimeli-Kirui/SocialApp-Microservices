using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comments_Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comments_Service.Data
{
    public class CommentsDbContext : DbContext
    {
        public CommentsDbContext(DbContextOptions<CommentsDbContext> options) : base(options) { }

        public DbSet<Comment> Comments { get; set; }
    }
}