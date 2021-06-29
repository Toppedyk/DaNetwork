using System;
using System.Collections.Generic;
using DaNetwork.Server.Models;
using DaNetwork.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace DaNetwork.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController: ControllerBase
    {
        private readonly AccountService _serviceAcct;
        private readonly CommentsService _serviceComm;
        private readonly PostsService _servicePost; 
        private readonly LikesService _serviceLike;

    public CommentsController(AccountService serviceAcct, CommentsService serviceComm, PostsService servicePost, LikesService serviceLike)
    {
      _serviceAcct = serviceAcct;
      _serviceComm = serviceComm;
      _servicePost = servicePost;
      _serviceLike = serviceLike;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Comment>> GetAllComments()
    {
      try
      {
          IEnumerable<Comment> comments = _serviceComm.GetAllComments();
          return Ok(comments);
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Comment> GetCommentById(int id)
    {
      try
      {
          
      }
      catch (System.Exception)
      {
          
          throw;
      }
    }









  }
}