using AspNetCore.DynamicProxies.Models;
using AspNetCore.DynamicProxies.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.DynamicProxies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IBlogService _service;

        public TestController(IBlogService service)
        {
            _service = service;
        }

        [HttpGet]
        public BlogPost Get() => _service.GetPost(1);
    }
}
