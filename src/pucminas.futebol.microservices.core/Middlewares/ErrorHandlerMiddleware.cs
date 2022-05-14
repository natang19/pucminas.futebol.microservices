﻿using Microsoft.AspNetCore.Http;
using pucminas.futebol.microservices.core.Exceptions;
using System.Net;
using System.Text.Json;

namespace pucminas.futebol.microservices.core
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    BusinessException e => (int)HttpStatusCode.BadRequest,// custom application error
                    NotFoundException e => (int)HttpStatusCode.NotFound,// not found error
                    _ => (int)HttpStatusCode.InternalServerError,// unhandled error
                };

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
