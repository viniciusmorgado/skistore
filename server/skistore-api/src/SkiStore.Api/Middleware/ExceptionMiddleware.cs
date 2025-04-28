using System.Net;
using System.Text.Json;
using SkiStore.Api.Errors;

namespace SkiStore.Api.Middleware;

public class ExceptionMiddleware(IHostEnvironment environment, RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception, environment);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, IHostEnvironment environment)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        return context.Response.WriteAsync(
            JsonSerializer.Serialize(
                environment.IsDevelopment()
                    ? new ApiErrorResponse(context.Response.StatusCode, exception.Message, exception.StackTrace)
                    : new ApiErrorResponse(context.Response.StatusCode, exception.Message, "Internal Server Error"),
                // TODO: Verify the cache here.
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            )
        );
    }
}
