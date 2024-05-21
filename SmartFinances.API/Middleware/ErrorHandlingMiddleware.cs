using Microsoft.AspNetCore.Mvc;
using SmartFinances.Application.Exceptions;
using System.Net;
using System.Security.Permissions;
using System.Text.Json;

namespace SmartFinances.API.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ProblemDetails problemDetails = new();

            switch(ex) 
            {
                case NotFoundException:
                    problemDetails.Status = (int)HttpStatusCode.NotFound;
                    problemDetails.Type = "Not found";
                    problemDetails.Title = "Not found";
                    problemDetails.Detail = ex.Message;
                    break;
                case ValidationException validationException:
                    problemDetails.Status = (int)HttpStatusCode.BadRequest;
                    problemDetails.Type = "Not found";
                    problemDetails.Title = "Validation error";
                    problemDetails.Detail = "One or more validation errors occurred.";
                    problemDetails.Extensions.Add("errors", validationException.Errors);
                    break;
                default:
                    problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                    problemDetails.Type = "Internal server error";
                    problemDetails.Title = "Internal server error";
                    problemDetails.Detail = ex.Message;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = problemDetails.Status.Value;

            string json = JsonSerializer.Serialize(problemDetails);

            await context.Response.WriteAsync(json);

        }
    }
}
