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
 
// // NOTE Review this logic with someone
//     [HttpGet]
//     [Authorize]
//     public async Task<ActionResult<Like>> DeleteOrCreateLike(int postId)
//     {
//         try
//         {
//             Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
//             return Ok(_serviceLike.CreateOrDeleteLike(postId, userInfo.Id));
//         }
//         catch (Exception e)
//         {
//             return BadRequest(e.Message);
//         }
//     }








  }
}