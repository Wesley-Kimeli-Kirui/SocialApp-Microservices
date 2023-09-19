using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comments_Service.Entities.Dtos
{
    public class UserDto
    {
        public string? UserId { get; set; }
        public Guid Id { get; set; }
        public string? PostId { get; set; }
    }
}