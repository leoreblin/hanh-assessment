using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebAPI.Middlewares;

internal sealed class GlobalExceptionHandlerMiddleware(
	ILogger<GlobalExceptionHandlerMiddleware> logger) : IMiddleware
{
	private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
            _logger.LogError(ex, "{Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
		}
    }

	private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "Server error",
            Title = "Server error",
            Detail = $"An internal error has occurred: {exception.Message} - {exception.InnerException}"
        };

        string json = JsonSerializer.Serialize(problemDetails);
        await context.Response.WriteAsync(json);
        context.Response.ContentType = "application/json";
    }
}
