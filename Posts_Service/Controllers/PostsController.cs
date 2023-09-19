using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Posts_Service.Models;
using Posts_Service.Models.Dtos;
using Posts_Service.Services.IServices;

namespace Posts_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPosts _postsService;
        private readonly IMapper _mapper;
        private readonly ResponseDto _responseDto;

        public PostsController(IPosts postsService, IMapper mapper)
        {
            _postsService = postsService;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }
        private string GetUserIdFromToken()
        {
            var token = Request.Headers["Authorization"].ToString();
            var decodedToken = new JwtSecurityTokenHandler().ReadJwtToken(token.Split(" ")[1]);
            return decodedToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
        }
        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] PostRequestDto postRequestDto)
        {
            var newPost = _mapper.Map<Posts>(postRequestDto);
            var userId = GetUserIdFromToken();
            newPost.UserId = Guid.Parse(userId);
            var response = await _postsService.CreatePost(newPost);
            if (response != null)
            {
                _responseDto.IsSuccess = true;
                _responseDto.Message = response;
                return Ok(_responseDto);
            }
            _responseDto.IsSuccess = false;
            _responseDto.Message = "Something went wrong";
            return BadRequest(_responseDto);
        }
        [HttpGet]
        public async Task<ActionResult> UpdatePost([FromBody] PostRequestDto postRequestDto)
        {
            var post = _mapper.Map<Posts>(postRequestDto);
            var response = await _postsService.UpdatePost(post);
            if (response != null)
            {
                _responseDto.IsSuccess = true;
                _responseDto.Message = response;
                return Ok(_responseDto);
            }
            _responseDto.IsSuccess = false;
            _responseDto.Message = "Something went wrong";
            return BadRequest(_responseDto);
        }
        [HttpPut("{postId}/{postContent}")]
        public async Task<ActionResult> UpdatePostContent(Guid postId, string postContent)
        {
            var response = await _postsService.UpdatePostContent(postId, postContent);
            if (response != null)
            {
                _responseDto.IsSuccess = true;
                _responseDto.Message = response;
                return Ok(_responseDto);
            }
            _responseDto.IsSuccess = false;
            _responseDto.Message = "Something went wrong";
            return BadRequest(_responseDto);
        }
        [HttpGet("{postId}")]
        public async Task<ActionResult> GetPostById(Guid postId)
        {
            var post = await _postsService.GetPostById(postId);
            if (post != null)
            {
                _responseDto.IsSuccess = true;
                _responseDto.Payload = post;
                return Ok(_responseDto);
            }
            _responseDto.IsSuccess = false;
            _responseDto.Message = "Something went wrong";
            return NotFound(_responseDto);
        }
        [HttpGet("delete/{postId}")]
        public async Task<ActionResult> DeletePost(Guid postId)
        {
            var post = await _postsService.GetPostById(postId);
            if (post != null)
            {
                var response = await _postsService.DeletePost(postId);
                _responseDto.IsSuccess = true;
                _responseDto.Message = response;
                return Ok(_responseDto);
            }
            _responseDto.IsSuccess = false;
            _responseDto.Message = "Something went wrong";
            return NotFound(_responseDto);
        }
    }
}