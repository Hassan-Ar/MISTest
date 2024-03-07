using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class LoggingMiddleware : IMiddleware
{
    private readonly string _logFilePath;

    public LoggingMiddleware(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Log request information
        var requestInfo = $"{DateTime.UtcNow} - {context.Request.Method} {context.Request.Path}";
        await WriteLogAsync(requestInfo);

        // Call the next middleware in the pipeline
        await next(context);

        // Log response information
        var responseInfo = $"{DateTime.UtcNow} - Status code: {context.Response.StatusCode}";
        await WriteLogAsync(responseInfo);
    }

    private async Task WriteLogAsync(string logMessage)
    {
        try
        {
            await using var writer = new StreamWriter(_logFilePath, true, Encoding.UTF8);
            await writer.WriteLineAsync(logMessage);
        }
        catch (Exception ex)
        {
            // Handle exceptions, e.g., log to console
            Console.WriteLine($"Error writing log: {ex.Message}");
        }
    }
}