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

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                await HandleNotFoundExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
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