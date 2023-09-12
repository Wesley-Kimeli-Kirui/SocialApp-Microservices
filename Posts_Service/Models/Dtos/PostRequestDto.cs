using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posts_Service.Models.Dtos
{
    public class PostRequestDto
    {
        public Guid UserId { get; set; }
        public string PostTitle { get; set; } = string.Empty;
        public string PostContent { get; set; } = string.Empty;
        public DateTime PostDate { get; set; } = DateTime.Now;
    }
}