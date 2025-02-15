﻿using BE.Api.Extensions;
using FluentValidation;

namespace BE.Api.Middlewares;

public class ExceptionHandlingMiddleware: IMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
    {
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);

            var response = context.Response;
            response.ContentType = "application/json";

            if (ex is ValidationException validationException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                await response.WriteAsync(validationException.ValidationResult());
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                await response.WriteAsync(ex.Message);
            }
        }
    }
}

