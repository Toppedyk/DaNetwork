using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DaNetwork.Server.Models;
using Dapper;

namespace DaNetwork.Server.Repositories
{
  public class CommentsRepository
  {


    private readonly IDbConnection _db;

    public CommentsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Comment> GetAllComments()
    {
      string sql = @"
      SELECT 
      c.*,
      a.*
      FROM comments c
      JOIN accounts a ON a.id = c.creatorId;";
      return _db.Query<Comment, Profile, Comment>(sql,(c,a)=>{
        c.Creator = a;
        return c;
      },splitOn:"id").ToList();
    }

    internal IEnumerable<Comment> GetCommentsByProfileId(string id)
    {
      string sql = @"
      SELECT
      c.*,
      a.*
      FROM comments c
      JOIN accounts a ON a.id = c.creatorId
      WHERE c.creatorId = @id;";
      return _db.Query<Comment, Profile, Comment>(sql,(c,a)=>{
        c.Creator = a;
        return c;
      }, new{id}).ToList();
    }

    internal IEnumerable<Comment> GetCommentsByPostId(int id)
    {
      string sql=@"
      SELECT
      c.*,
      a.*
      FROM comments c
      JOIN accounts a ON a.id = c.creatorId
      WHERE c.postId = @id;";
      return _db.Query<Comment,Profile,Comment>(sql,(c,a)=>{
        c.Creator = a;
        return c;
      }, new{id}).ToList();
    }

    internal Comment GetCommentById(int id)
    {
      string sql=@"
      SELECT 
      c.*,
      a.*
      FROM comments c
      JOIN accounts a ON a.id = c.creatorId
      WHERE c.id = @id;";
      return _db.Query<Comment, Profile, Comment>(sql,(c,a)=>{
        c.Creator = a;
        return c;
      },new{id}).FirstOrDefault();
    }

    internal Comment CreateComment(Comment c)
    {
      string sql=@"
      INSERT INTO
      comments(postId, creatorId, body)
      VALUES(@PostId, @CreatorId, @Body);
      SELECT LAST_INSERT_ID();";
      c.Id = _db.ExecuteScalar<int>(sql,c);
      return c;
    }

    internal void DeleteComment(int commentId)
    {
      throw new NotImplementedException();
    }
  }
}