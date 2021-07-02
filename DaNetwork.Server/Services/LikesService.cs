using System;
using System.Collections.Generic;
using DaNetwork.Server.Models;
using DaNetwork.Server.Repositories;

namespace DaNetwork.Server.Services
{
  public class LikesService
  {

    private readonly LikesRepository _repo;
public LikesService(LikesRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Like> GetLikesByProfileId(string id)
    {
      return _repo.GetLikesByProfileId(id);
    }

    internal IEnumerable<Like> GetLikesByPostId(int id)
    {
      return _repo.GetLikesByPostId(id);
    }

    internal object CreateOrDeleteLike(int postId, string id)
    {
      throw new NotImplementedException();
    }
  }
}