using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Posts_Service.Models.Dtos;
using Posts_Service.Services.IServices;

namespace Posts_Service.Services
{
    public class CommentsService : IComments
    {
        private readonly IHttpClientFactory _client;
        public CommentsService(IHttpClientFactory client)
        {
            _client = client;
        }
        public Task<List<CommentsDto>> GetCommentsAsync()
        {
            //create a client
            var client = _client.CreateClient("CommentsService");
            //make a request
            var response = client.GetAsync("api/comments").Result;
            //read the response
            var responseAsString = response.Content.ReadAsStringAsync().Result;
            //deserialize the response
            var comments = JsonConvert.DeserializeObject<List<CommentsDto>>(responseAsString);
            return Task.FromResult(comments);
        }
    }
}