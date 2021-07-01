using System;
using System.Collections.Generic;
using DaNetwork.Server.Models;

namespace DaNetwork.Server.Repositories
{
  public class CommentsRepository
  {
    internal IEnumerable<Comment> GetAllComments()
    {
      throw new NotImplementedException();
    }

    internal IEnumerable<Comment> GetCommentsByProfileId(string id)
    {
      throw new NotImplementedException();
    }

    internal IEnumerable<Comment> GetCommentsByPostId(int id)
    {
      throw new NotImplementedException();
    }
  }
}