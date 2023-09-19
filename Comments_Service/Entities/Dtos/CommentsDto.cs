using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comments_Service.Entities.Dtos
{
    public class CommentsDto
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }
        public string? UserId { get; set; }
        public string? PostId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
