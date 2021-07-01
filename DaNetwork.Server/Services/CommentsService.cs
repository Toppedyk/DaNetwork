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
      return _repo.GetCommentsByPostId(id);
    }

    internal IEnumerable<Comment> GetAllComments()
    {
      return _repo.GetAllComments();
    }

    internal Comment GetCommentById(int id)
    {
      Comment comment = _repo.GetCommentById(id);
      if(comment == null){
        throw new Exception("Invalid Id");
      }
      return comment;
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