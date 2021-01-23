using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
//using System.Threading.Tasks;

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

        // If you require an async interceptor, I suggest:

        //public void Intercept(IInvocation invocation)
        //{
        //    var delayTask = InterceptAsync(invocation);
        //    delayTask.Wait();
        //}

        //public async Task InterceptAsync(IInvocation invocation)
        //{
        //    _logger.LogDebug($"Calling method {invocation.TargetType}.{invocation.Method.Name}.");

        //    invocation.Proceed();
        //}
    }
}
