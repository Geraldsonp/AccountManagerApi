using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using ApplicationLayer.Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace AccountManagerAPi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;


        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _logger.LogInformation("Handling request: " + context.Request.Path);
                _logger.LogInformation("Request method: " + context.Request.Method);
                await _next(context);
            }
            catch (DomainException ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleNotFoundExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }



        private static Task HandleNotFoundExceptionAsync(HttpContext context, DomainException ex)
        {


            var result = JsonSerializer.Serialize(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.StatusCode;
            return context.Response.WriteAsync(result);
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "An error occurred while processing your request.";

            if (ex is ArgumentException)
            {
                statusCode = HttpStatusCode.BadRequest;
                message = ex.Message;
            }

            var result = JsonSerializer.Serialize(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}