using System;
using System.Collections.Generic;
using DaNetwork.Server.Models;
using DaNetwork.Server.Repositories;

namespace DaNetwork.Server.Services
{
  public class PostsService
  {
    private readonly PostsRepository _repo;

    public PostsService(PostsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Post> GetPostsByProfileId(string id)
    {
      throw new NotImplementedException();
    }

    internal IEnumerable<Post> GetAllPosts()
    {
      throw new NotImplementedException();
    }

    internal Post GetPostById(int id)
    {
      throw new NotImplementedException();
    }

    internal Post CreatePost(Post p)
    {
      throw new NotImplementedException();
    }

    internal void DeletePost(int id1, string id2)
    {
      throw new NotImplementedException();
    }

    internal Post UpdatePost(Post p, string id)
    {
      throw new NotImplementedException();
    }
  }
}