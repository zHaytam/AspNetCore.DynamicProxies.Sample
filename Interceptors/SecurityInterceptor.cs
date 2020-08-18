using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace AspNetCore.DynamicProxies.Interceptors
{
    public class SecurityInterceptor : IInterceptor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<SecurityInterceptor> _logger;

        public SecurityInterceptor(IHttpContextAccessor httpContextAccessor, ILogger<SecurityInterceptor> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            if (!_httpContextAccessor.HttpContext.Request.Headers.TryGetValue("SECRET_KEY", out var values))
                throw new InvalidOperationException("SECRET_KEY not found in request headers.");

            if (values[0] != "VERY_SECRET_KEY")
            {
                _logger.LogWarning($"Method {invocation.TargetType}.{invocation.Method.Name} called with secret key '{values}'");
                throw new InvalidOperationException("Invalid SECRET_KEY value.");
            }

            invocation.Proceed();
        }
    }
}
