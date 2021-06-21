using System;
using System.Collections.Generic;
using DaNetwork.Server.Models;
using DaNetwork.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace DaNetwork.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class ProfilesController : ControllerBase
    {
        private readonly AccountService _serviceAcct;
        private readonly CommentsService _serviceComm;
        private readonly PostsService _servicePost; 
        private readonly LikesService _serviceLike;

    public ProfilesController(AccountService serviceAcct, CommentsService serviceComm, PostsService servicePost, LikesService serviceLike)
    {
      _serviceAcct = serviceAcct;
      _serviceComm = serviceComm;
      _servicePost = servicePost;
      _serviceLike = serviceLike;
    }

        [HttpGet("{id}")]
        public ActionResult<Profile> GetProfileById(string id)
        {
            try
            {
                Profile profile = _serviceAcct.GetProfileById(id);
                return Ok(profile);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/posts")]
        public ActionResult<IEnumerable<Post>> GetPostsByProfileId(string id)
        {
            try
            {
                IEnumerable<Post> posts = _servicePost.GetPostsByProfileId(id);
                return Ok(posts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/likes")]
        public ActionResult<IEnumerable<Like>> GetLikesByProfileId(string id)
        {
            try
            {
                IEnumerable<Like> likes = _serviceLike.GetLikesByProfileId(id);
                return Ok(likes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/comments")]
        public ActionResult<IEnumerable<Comment>> GetCommentsByProfileId(string id)
        {
            try
            {
                IEnumerable<Comment> comments = _serviceComm.GetCommentsByProfileId(id);
                return Ok(comments);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }








  }
}