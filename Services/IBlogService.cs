using AspNetCore.DynamicProxies.Models;

namespace AspNetCore.DynamicProxies.Services
{
    public interface IBlogService
    {
        void DisablePost(BlogPost post);
        BlogPost GetPost(int id);
    }
}