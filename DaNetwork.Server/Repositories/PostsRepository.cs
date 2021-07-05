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
      string sql = @"
      SELECT 
      p.*,
      a.*
      FROM posts p
      JOIN accounts a ON a.id = p.creatorId
      where k.creatorId = @id;";
      return _db.Query<Post, Profile,Post>(sql,(p,a)=>{
        p.Creator = a;
        return p;
      }, new {id}).ToList();
    }

    internal Post getPostById(int id)
    {
      string sql=@"
      SELECT 
      p.*,
      a.*
      FROM posts p
      JOIN accounts a ON a.id = p.creatorId
      WHERE p.id = @id;";
      return _db.Query<Post, Profile, Post>(sql,(p,a)=>{
        p.Creator = a;
        return p;
      }, new {id}).FirstOrDefault();
    }

    internal Post CreatePost(Post p)
    {
      string sql = @"
      INSERT INTO 
      posts(body, imgUrl, likes)
      VALUES(@Body, @ImgUrl, @Likes);
      SELECT LAST_INSERT_ID();";
      p.Id = _db.ExecuteScalar<int>(sql,p);
      return p;
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