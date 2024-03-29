using System;
using System.Collections.Generic;
using DaNetwork.Server.Models;
using DaNetwork.Server.Repositories;

namespace DaNetwork.Server.Services
{
  public class PostsService
  {
    private readonly PostsRepository _repo;

    public PostsService(PostsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Post> GetPostsByProfileId(string id)
    {
      return _repo.GetPostsByProfileId(id);
    }

    internal IEnumerable<Post> GetAllPosts()
    {
      return _repo.GetAllPosts();
    }

    internal Post GetPostById(int id)
    {
      Post post = _repo.getPostById(id);
      if(post== null){
        throw new Exception("Invalid ID");
      }
      return post;
    }

    internal Post CreatePost(Post p)
    {
      return _repo.CreatePost(p);
    }

    internal void DeletePost(int postId, string creatorId)
    {
      Post post = GetPostById(postId);
      if(post.CreatorId != creatorId){
        throw new Exception("You cannot delete another users post");
      }
      _repo.DeletePost(postId);
    }

    internal Post UpdatePost(Post p, string id)
    {
      Post post = GetPostById(p.Id);
      if(id != p.CreatorId){
        throw new Exception("You cannot edit this!");
      }
      post.Body = p.Body.Length > 0 ? p.Body : post.Body;
      post.ImgUrl = p.ImgUrl.Length > 0 ? p.ImgUrl : post.ImgUrl;
      post.Likes=post.Likes;
      return _repo.UpdatePost(post);
    }
  }
}