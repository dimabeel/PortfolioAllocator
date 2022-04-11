using System.Net;
using System.Text.Json;
using Allocator.API.Exceptions;

namespace Allocator.API.Middlewares;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    //private readonly ILogger _logger;

    public CustomExceptionHandlerMiddleware(RequestDelegate next/*, ILogger logger*/)
    {
        _next = next;
        //_logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (HttpResponseException e)
        {
            //_logger.LogError(e, e.Message);
            await HandleExceptionAsync(httpContext, e);
        }
        catch (Exception e)
        {
            //_logger.LogCritical(e, e.Message);
            var internalError = new HttpResponseException(500, "Unexpected error", "Internal Server Error");
            await HandleExceptionAsync(httpContext, internalError);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, HttpResponseException exception)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = exception.StatusCode;

        var details = new ErrorDetails()
        {
            Status = httpContext.Response.StatusCode,
            Message = exception.Value,
            TraceId = httpContext.TraceIdentifier,
            Title = exception.Title
        };
        
        await httpContext.Response.WriteAsync(details.ToString());
    }
}
