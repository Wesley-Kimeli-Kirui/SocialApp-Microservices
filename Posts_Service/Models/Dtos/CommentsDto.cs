using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posts_Service.Models.Dtos
{
    public class CommentsDto
    {
        public Guid CommentId { get; set; }
        public string Comments { get; set; } = string.Empty;
        public DateTime CommentDate { get; set; } = DateTime.Now;
    }
}