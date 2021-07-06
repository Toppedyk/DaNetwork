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
      post.Likes++;
      _repoPost.UpdatePost(post);
      return _repo.CreateLike(l);
    }

    internal void DeleteLike(int postId, string userId)
    {
      throw new NotImplementedException();
    }
  }
}