using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Posts_Service.Models.Dtos;

namespace Posts_Service.Services.IServices
{
    public interface IComments
    {
        Task<List<CommentsDto>> GetCommentsAsync();
    }
}