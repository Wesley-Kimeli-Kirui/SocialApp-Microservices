using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Posts_Service.Models.Dtos;

namespace Posts_Service.Models
{
    public class Posts
    {
        [Key]
        public Guid PostId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public string PostTitle { get; set; } = string.Empty; // property representing the title of the post
        public string PostContent { get; set; } = string.Empty; // represents the body content of the post
        public DateTime PostDate { get; set; } = DateTime.Now;

        [NotMapped]
        public IEnumerable<CommentsDto>? Comments { get; set; }
    }
}