using System;
using System.Collections.Generic;
using DaNetwork.Server.Models;

namespace DaNetwork.Server.Repositories
{
  public class PostsRepository
  {
    internal IEnumerable<Post> GetAllPosts()
    {
      throw new NotImplementedException();
    }

    internal IEnumerable<Post> GetPostsByProfileId(string id)
    {
      throw new NotImplementedException();
    }

    internal Post getPostById(int id)
    {
      throw new NotImplementedException();
    }

    internal Post CreatePost(Post p)
    {
      throw new NotImplementedException();
    }

    internal void DeletePost(int postId)
    {
      throw new NotImplementedException();
    }

    internal Post UpdatePost(Post post)
    {
      throw new NotImplementedException();
    }
  }
}