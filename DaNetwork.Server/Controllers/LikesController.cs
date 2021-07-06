using System;
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
    public class LikesController : ControllerBase
    {
        private readonly AccountService _serviceAcct;
        private readonly CommentsService _serviceComm;
        private readonly PostsService _servicePost; 
        private readonly LikesService _serviceLike;

    public LikesController(AccountService serviceAcct, CommentsService serviceComm, PostsService servicePost, LikesService serviceLike)
    {
      _serviceAcct = serviceAcct;
      _serviceComm = serviceComm;
      _servicePost = servicePost;
      _serviceLike = serviceLike;
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Like>> CreateLike([FromBody] Like l)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          l.CreatorId = userInfo.Id;

          Like like = _serviceLike.CreateLike(l);
          return Ok(like);
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<String>> DeleteLike(int id)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          _serviceLike.DeleteLike(id, userInfo.Id);
          return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }

  }
}