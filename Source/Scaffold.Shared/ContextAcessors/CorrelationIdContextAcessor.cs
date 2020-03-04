using Microsoft.AspNetCore.Http;
using Serilog;
using System;

namespace Scaffold.Shared.ContextAcessors
{
    public class CorrelationIdContextAcessor : ICorrelationIdContextAcessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CorrelationIdContextAcessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUid()
        {
            try
            {
                var context = _httpContextAccessor.HttpContext;
                var result = context?.Items["X-Request-ID"] as string;

                return result;
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Unable to get Request ID header");

                return string.Empty;
            }
        }

        public string GetCid()
        {
            try
            {
                var context = _httpContextAccessor.HttpContext;
                var result = context?.Items["X-Correlation-ID"] as string;

                return result;
            }
            catch (Exception ex)
            {
                Log.Warning(ex, "Unable to get Correlation ID header");

                return string.Empty;
            }
        }
    }
}
