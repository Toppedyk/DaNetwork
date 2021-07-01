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
      return _repo.CreateComment(c);
    }

    internal void DeleteComment(int commentId, string userId)
    {
      Comment comment = GetCommentById(commentId);
      if(comment.CreatorId != userId){
        throw new Exception("You cannot delte this!");
      }
      _repo.DeleteComment(commentId);
    }
  }
}