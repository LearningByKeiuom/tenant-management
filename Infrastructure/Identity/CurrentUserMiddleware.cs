using Microsoft.AspNetCore.Http;

namespace Infrastructure.Identity;

public class CurrentUserMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
       
        await next(context);
    }
}