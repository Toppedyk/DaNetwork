using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using DaNetwork.Server.Models;
using DaNetwork.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DaNetwork.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PostsController: ControllerBase
    {
        private readonly AccountService _serviceAcct;
        private readonly CommentsService _serviceComm;
        private readonly PostsService _servicePost; 
        private readonly LikesService _serviceLike;

    public PostsController(AccountService serviceAcct, CommentsService serviceComm, PostsService servicePost, LikesService serviceLike)
    {
      _serviceAcct = serviceAcct;
      _serviceComm = serviceComm;
      _servicePost = servicePost;
      _serviceLike = serviceLike;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Post>> GetAllPosts()
    {
      try
      {
          IEnumerable<Post> posts = _servicePost.GetAllPosts();
          return Ok(posts);
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Post> GetPostById(int id)
    {
      try
      {
          Post post = _servicePost.GetPostById(id);
          return Ok(post);
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/comments")]
    public ActionResult<IEnumerable<Comment>> GetCommentsByPostId(int id)
    {
      try
      {
          Post post = _servicePost.GetPostById(id);
          if(post == null){
            return BadRequest("Invalid Id");
          }
          IEnumerable<Comment> comments = _serviceComm.GetCommentsByPostId(id);
          return Ok(comments);
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/likes")]
    public ActionResult<IEnumerable<Like>> GetLikesByPostId(int id)
    {
      try
      {
          IEnumerable<Like> likes = _serviceLike.GetLikesByPostId(id);
          return Ok(likes);
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post p)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          p.CreatorId = userInfo.Id;

          Post post = _servicePost.CreatePost(p);
          post.Creator = userInfo;
          return Ok(post);
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeletePost(int id)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          _servicePost.DeletePost(id, userInfo.Id);
          return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Post>> UpdatePost(int id, [FromBody] Post p)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          p.Id = id;
          Post post = _servicePost.UpdatePost(p, userInfo.Id);
          post.Creator = userInfo;
          return Ok(post);
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }









    
  }
}