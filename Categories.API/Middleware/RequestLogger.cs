namespace Categories.API.Middleware;

public class RequestLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggerMiddleware> _logger;

    public RequestLoggerMiddleware(RequestDelegate next, ILogger<RequestLoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.EnableBuffering();

        string bodyContent = string.Empty;
        if (context.Request.ContentType != null && context.Request.ContentType.Contains("application/json"))
        {
            bodyContent = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0; // Reset the stream for subsequent middleware
        }

        string queryString = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : "";

        _logger.LogInformation($"Incoming request: {context.Request.Method} {context.Request.Path}, Query: {queryString}, Body: {bodyContent}");

        await _next(context);
    }
}

public static class RequestLoggerMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestLoggerMiddleware>();
    }
}