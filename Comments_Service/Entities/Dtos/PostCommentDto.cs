using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comments_Service.Entities.Dtos
{
    public class PostCommentDto
    {
        public string? Content { get; set; } = string.Empty;
        public string PostId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}