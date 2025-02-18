using System.Net;
using PokeConnection.Domain.Exceptions;
using PokeConnection.Domain.Models;

namespace PokeConnection.API.Middlewares;

public class HandleException(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = ex switch
        {
            NaoEncontradoException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.BadRequest
        };

        context.Response.ContentType = "application/json";

        ErrorResponse errorResponse = new(context.Response.StatusCode, ex.Message);
        await context.Response.WriteAsync(errorResponse.ToString());
    }
}
