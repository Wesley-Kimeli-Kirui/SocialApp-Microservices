using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comments_Service.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
        public string PostId { get; set; } = string.Empty;
        public Post? Post { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}