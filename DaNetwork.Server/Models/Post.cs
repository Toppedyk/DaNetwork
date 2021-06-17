using System;

namespace DaNetwork.Server.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Body { get; set; }
        public string ImgUrl { get; set; }
        public int Likes { get; set; }
        public string CreatorId { get; set; }
    }
}