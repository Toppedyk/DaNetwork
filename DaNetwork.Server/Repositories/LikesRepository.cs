using System;
using System.Collections.Generic;
using DaNetwork.Server.Models;

namespace DaNetwork.Server.Repositories
{
  public class LikesRepository
  {
    internal IEnumerable<Like> GetLikesByProfileId(string id)
    {
      throw new NotImplementedException();
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