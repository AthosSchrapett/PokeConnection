namespace PokeConnection.API.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware
    (
        RequestDelegate next, 
        ILogger<RequestLoggingMiddleware> logger
    )
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;
        var startTime = DateTime.UtcNow;

        await _next(context);

        var endTime = DateTime.UtcNow;
        var response = context.Response;

        _logger.LogInformation
        (
            "HTTP {Method} {Path} responded {StatusCode} in {Duration}ms",
            request.Method,
            request.Path,
            response.StatusCode,
            (endTime - startTime).TotalMilliseconds
        );
    }
}
