using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DaNetwork.Server.Models;
using Dapper;

namespace DaNetwork.Server.Repositories
{
  public class PostsRepository
  {

    private readonly IDbConnection _db;

    public PostsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Post> GetAllPosts()
    {
      string sql = @"
      SELECT
      p*,
      a*
      FROM posts p
      JOIN accounts a ON a.id = p.creatorId;";
      return _db.Query<Post, Profile, Post>(sql,(p,a)=>{
        p.Creator = a;
        return p;
      },splitOn: "id").ToList();
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