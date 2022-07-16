using Microsoft.AspNetCore.Builder;

namespace NOM.WebApi.Middleware;

/// <summary>
/// haitc 02/06/2022
/// </summary>
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}