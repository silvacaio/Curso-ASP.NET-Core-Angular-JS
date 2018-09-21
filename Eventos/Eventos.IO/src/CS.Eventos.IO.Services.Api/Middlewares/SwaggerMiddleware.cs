
using CS.Eventos.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CS.Eventos.IO.Services.Api.Middlewares
{
    public class SwaggerMiddleware
    {
        private readonly RequestDelegate _next;
     //   private readonly IUser _user;

        public SwaggerMiddleware(RequestDelegate next)
        {
            _next = next;            
        }

        public async Task Invoke(HttpContext context, IUser user)
        {
            //Só permite usuarios autenticados acessarem o swagger
            if(context.Request.Path.StartsWithSegments("/swagger") &&
                !user.IsAuthenticated())
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            await _next.Invoke(context);
        }
    }

    public static class SwaggerMiddlewareExtension
    {
        public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerMiddleware>();
        }
    }
}
