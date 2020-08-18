using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace AspNetCore.DynamicProxies.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            _logger.LogDebug($"Calling method {invocation.TargetType}.{invocation.Method.Name}.");
            invocation.Proceed();
        }
    }
}
