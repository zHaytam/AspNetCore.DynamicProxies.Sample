using AspNetCore.DynamicProxies.Models;
using System;

namespace AspNetCore.DynamicProxies.Services
{
    public class BlogService : IBlogService
    {
        public BlogPost GetPost(int id)
        {
            return new BlogPost
            {
                Id = id,
                Title = "Test",
                Description = "Test",
                Disabled = false,
                Created = DateTime.UtcNow
            };
        }

        public void DisablePost(BlogPost post)
        {
            post.Disabled = true;
        }
    }
}
