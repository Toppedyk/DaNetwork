using System;
using System.Collections.Generic;
using DaNetwork.Server.Models;
using DaNetwork.Server.Repositories;

namespace DaNetwork.Server.Services
{
  public class LikesService
  {

    private readonly LikesRepository _repo;
    private readonly PostsRepository _repoPost;

    public LikesService(LikesRepository repo, PostsRepository repoPost)
    {
      _repo = repo;
      _repoPost = repoPost;
    }

    internal IEnumerable<Like> GetLikesByProfileId(string id)
    {
      return _repo.GetLikesByProfileId(id);
    }

    internal IEnumerable<Like> GetLikesByPostId(int id)
    {
      return _repo.GetLikesByPostId(id);
    }

    internal Like CreateLike(Like l)
    {
      Post post = _repoPost.getPostById(l.PostId);
      if(post== null){
        throw new Exception("Invalid ID");
      }
      post.Likes++;
      _repoPost.UpdatePost(post);
      return _repo.CreateLike(l);
    }

    internal void DeleteLike(int likeId, string userId)
    {
      Like like = _repo.getLikeById(likeId);
      if(like == null){
        throw new Exception("Invalid ID");
      }
      Post post = _repoPost.getPostById(like.PostId);
      if(post== null){
        throw new Exception("Invalid ID");
      }
      post.Likes--;
      _repoPost.UpdatePost(post);

      _repo.DeleteLike(likeId);
    }
  }
}