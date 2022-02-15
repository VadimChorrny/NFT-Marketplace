using BLL.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeResponse(HttpContext context,HttpStatusCode code, string message)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var result = JsonSerializer.Serialize(new { message = message });
            await response.WriteAsync(result);
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(HttpException exception)
            {
                await InvokeResponse(context,exception.StatusCode, exception.Message);
            }
            catch(KeyNotFoundException exception)
            {
                await InvokeResponse(context,HttpStatusCode.NotFound, exception.Message);
            }
            catch (Exception error)
            {
                await InvokeResponse(context, HttpStatusCode.InternalServerError,error.Message);
            }
        }
    }
}
