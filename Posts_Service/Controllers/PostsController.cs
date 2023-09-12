using System;
using System.Collections.Generic;
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
        private readonly IPosts postsService;
        private readonly IMapper mapper;
        private readonly ResponseDto responseDto;

        public PostsController(IPosts postsService, IMapper mapper)
        {
            postsService = postsService;
            mapper = mapper;
            responseDto = new ResponseDto();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> CreatePost([FromBody] PostsDto postsDto)
        {
            if (postsDto == null)
            {
                responseDto.Message = "No post was found in the request body.";
                return BadRequest(responseDto);
            }

            try
            {
                var post = mapper.Map<Posts>(postsDto);
                var postId = await postsService.CreatePost(post);
                responseDto.Payload = postId;
                responseDto.IsSuccess = true;
                responseDto.Message = "Post was successfully created.";
                return Ok(responseDto);
            }
            catch (Exception e)
            {
                responseDto.Message = e.StackTrace;
                return StatusCode(500, responseDto);
            }
        }
        [HttpPut]
        public async Task<ActionResult<ResponseDto>> UpdatePost([FromBody] PostsDto postsDto)
        {
            if (postsDto == null)
            {
                responseDto.Message = "No post was found in the request body.";
                return BadRequest(responseDto);
            }

            try
            {
                var post = mapper.Map<Posts>(postsDto);
                var postId = await postsService.UpdatePost(post);
                responseDto.Payload = postId;
                responseDto.IsSuccess = true;
                responseDto.Message = "Post was successfully updated.";
                return Ok(responseDto);
            }
            catch (Exception e)
            {
                responseDto.Message = e.StackTrace;
                return StatusCode(500, responseDto);
            }
        }
        [HttpPut("{postId}")]
        public async Task<ActionResult<ResponseDto>> UpdatePostContent(Guid postId, string postContent)
        {
            if (postId == Guid.Empty)
            {
                responseDto.Message = "No post was found in the request body.";
                return BadRequest(responseDto);
            }

            try
            {
                var post = await postsService.UpdatePostContent(postId, postContent);
                responseDto.Payload = post;
                responseDto.IsSuccess = true;
                responseDto.Message = "Post was successfully updated.";
                return Ok(responseDto);
            }
            catch (Exception e)
            {
                responseDto.Message = e.StackTrace;
                return StatusCode(500, responseDto);
            }
        }
        [HttpGet("{postId}")]
        public async Task<ActionResult<ResponseDto>> GetPostById(Guid postId)
        {
            if (postId == Guid.Empty)
            {
                responseDto.Message = "No post was found in the request body.";
                return BadRequest(responseDto);
            }

            try
            {
                var post = await postsService.GetPostById(postId);
                responseDto.Payload = post;
                responseDto.IsSuccess = true;
                responseDto.Message = "Post was successfully retrieved.";
                return Ok(responseDto);
            }
            catch (Exception e)
            {
                responseDto.Message = e.StackTrace;
                return StatusCode(500, responseDto);
            }
        }
        [HttpDelete("{postId}")]
        public async Task<ActionResult<ResponseDto>> DeletePost(Guid postId)
        {
            if (postId == Guid.Empty)
            {
                responseDto.Message = "No post was found in the request body.";
                return BadRequest(responseDto);
            }

            try
            {
                var post = await postsService.DeletePost(postId);
                responseDto.Payload = post;
                responseDto.IsSuccess = true;
                responseDto.Message = "Post was successfully deleted.";
                return Ok(responseDto);
            }
            catch (Exception e)
            {
                responseDto.Message = e.StackTrace;
                return StatusCode(500, responseDto);
            }
        }

    }
}