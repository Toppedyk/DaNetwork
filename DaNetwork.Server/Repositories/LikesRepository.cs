using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DaNetwork.Server.Models;
using Dapper;

namespace DaNetwork.Server.Repositories
{
  public class LikesRepository
  {
    private readonly IDbConnection _db;

    public LikesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Like> GetLikesByProfileId(string id)
    {
      string sql = @"
      SELECT
      l.*
      FROM likes l
      WHERE l.creatorId = @ id;";
      return _db.Query<Like>(sql, new{id}).ToList();
    }

    internal IEnumerable<Like> GetLikesByPostId(int id)
    {
      throw new NotImplementedException();
    }

    internal Like CreateLike(Like l)
    {
      throw new NotImplementedException();
    }

    internal Like getLikeById(int likeId)
    {
      throw new NotImplementedException();
    }

    internal void DeleteLike(int likeId)
    {
      throw new NotImplementedException();
    }
  }
}