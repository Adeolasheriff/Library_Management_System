using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Library_Management_System.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Library_Management_System.Common;

public  class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var response = new ErrorResponse
            {
                Message = GetMessageFromException(ex),
                Errors = GetErrorsFromException(ex),
                StatusCode = (int)GetStatusCode(ex),
                Exception = ex.GetType().Name
            };

            context.Response.StatusCode = response.StatusCode;

            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
    private static string GetMessageFromException(Exception ex) => ex switch
    {
        UnauthorizedAccessException => "Unauthorized",
        KeyNotFoundException => "Resource not found",
        ArgumentException or InvalidOperationException => ex.Message,
        _ => "An unexpected error occurred"
    };

    private static object? GetErrorsFromException(Exception ex) => ex switch
    {
        ValidationException validationException => validationException.Message,
        _ => null
    };


    private static HttpStatusCode GetStatusCode(Exception ex) => ex switch
    {
        UnauthorizedAccessException => HttpStatusCode.Unauthorized,
        KeyNotFoundException => HttpStatusCode.NotFound,
        ArgumentException or InvalidOperationException => HttpStatusCode.BadRequest,
        _ => HttpStatusCode.InternalServerError
    };
}
