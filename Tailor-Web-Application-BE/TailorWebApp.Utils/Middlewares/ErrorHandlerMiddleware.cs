using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using TailorWebApp.Utils.Dictionaries;
using TailorWebApp.Utils.Dtos;
using TailorWebApp.Utils.Exceptions;

namespace TailorWebApp.Utils.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext.Response, ex);
            }
        }

        private static async Task HandleException(HttpResponse response, Exception exception)
        {
            var exceptionsDictionary = new ExceptionsStatusCodes().Exceptions;
            var statusCode = (int)exceptionsDictionary.GetValueOrDefault(
                exception.GetType(),
                defaultValue: HttpStatusCode.InternalServerError);
            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            var errorResponseDto = new ErrorResponseDto
            {
                TimeStamp = DateTime.UtcNow,
                StatusCode = statusCode,
                Message = exception.Message,
                Exception = exception.GetType().Name
            };

            if (exception is GlobalException globalException)
            {
                errorResponseDto.Errors = globalException.ErrorsDictionary;
            }

            await response.WriteAsync(JsonSerializer.Serialize(errorResponseDto));
        }
    }
}