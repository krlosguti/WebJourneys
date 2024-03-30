using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebJourneys.Application.Exceptions
{
    public class BadExceptionHandler(ILogger<BadExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<BadExceptionHandler> _logger = logger;

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is not BadHttpRequestException badRequestException)
            {
                return false;
            }

            _logger.LogError(
            badRequestException,
            "Exception occurred: {Message}",
            badRequestException.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Bad Request",
                Detail = badRequestException.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
