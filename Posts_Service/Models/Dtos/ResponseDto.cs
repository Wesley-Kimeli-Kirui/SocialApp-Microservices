using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Posts_Service.Models.Dtos
{
    public class ResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public object? Payload { get; set; }
    }
}