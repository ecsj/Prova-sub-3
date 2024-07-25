using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace API.Filters;

public class ExceptionFilter : IAsyncExceptionFilter
{
    ILogger<ExceptionFilter> _logger;

    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        var exType = context.Exception.Data["type"]?.ToString();

        ObjectResult result = new ObjectResult(new ExceptionModel()
        {
            message = context.Exception.Message,
            detail = context.Exception.InnerException != null ? context.Exception.InnerException.Message : context.Exception.Message,
        })
        {
            StatusCode = 400
        };
        context.Result = result;

        // Log the exception
        _logger.LogError("Unhandled exception occurred while executing request: {ex}", context.Exception);

        return;
    }
}

/// <summary>
/// type: "USER/APPLICATION_ERROR"
/// </summary>
public struct ExceptionModel
{
    public string type { get; set; }
    public string message { get; set; }
    public string detail { get; set; }
}
