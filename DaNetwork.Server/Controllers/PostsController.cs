using System;
using System.Collections.Generic;
using DaNetwork.Server.Models;
using DaNetwork.Server.Services;
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

    [HttpGet("id")]
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






    
  }
}