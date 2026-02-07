using Microsoft.Extensions.Primitives;
using Serilog.Context;

namespace Web.Api.Middleware;

public class RequestContextLoggingMiddleware(RequestDelegate next)
{
    private const string CorrelationIdHeaderName = "X-Correlation-ID";

    public Task Invoke(HttpContext context)
    {
        using (LogContext.PushProperty("X-Correlation-ID", GetCorrelationId(context)))
        {
            return next.Invoke(context);
        }
    }

    private static string GetCorrelationId(HttpContext context)
    {
        context.Request.Headers.TryGetValue(
            CorrelationIdHeaderName,
            out StringValues correlationId);

        return correlationId.FirstOrDefault() ?? context.TraceIdentifier;
    }
}
