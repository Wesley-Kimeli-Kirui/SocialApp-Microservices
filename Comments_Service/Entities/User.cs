using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comments_Service.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Post>? Posts { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}