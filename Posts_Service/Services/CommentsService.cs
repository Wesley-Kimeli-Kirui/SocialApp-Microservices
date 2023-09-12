using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Posts_Service.Models.Dtos;
using Posts_Service.Services.IServices;

namespace Posts_Service.Services
{
    public class CommentsService : IComments
    {
        public Task<List<CommentsDto>> GetCommentsAsync()
        {
            throw new NotImplementedException();
        }
    }
}