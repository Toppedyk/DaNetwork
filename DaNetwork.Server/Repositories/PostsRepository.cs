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
      string sql = @"DELETE FROM posts WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new{postId});
    }

    internal Post UpdatePost(Post post)
    {
      string sql=@"
      UPDATE posts
      SET
      body = @Body,
      imgUrl = @ImgUrl,
      likes=@Likes,
      creatorId=@CreatorId
      WHERE id = @Id;";
      _db.Execute(sql, post);
      return post;
    }
  }
}