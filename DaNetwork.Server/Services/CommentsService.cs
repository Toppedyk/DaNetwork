using System;
using System.Collections.Generic;
using DaNetwork.Server.Models;
using DaNetwork.Server.Repositories;

namespace DaNetwork.Server.Services
{
  public class CommentsService
  {
    private readonly CommentsRepository _repo;

    public CommentsService(CommentsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Comment> GetCommentsByProfileId(string id)
    {
      return _repo.GetCommentsByProfileId(id);
    }

    internal IEnumerable<Comment> GetCommentsByPostId(int id)
    {
      // Get post by id first?
      return _repo.GetCommentsByPostId(id);
    }

    internal IEnumerable<Comment> GetAllComments()
    {
      return _repo.GetAllComments();
    }

    internal Comment GetCommentById(int id)
    {
      throw new NotImplementedException();
    }

    internal Comment CreateComment(Comment c)
    {
      throw new NotImplementedException();
    }

    internal void DeleteComment(int id1, string id2)
    {
      throw new NotImplementedException();
    }
  }
}