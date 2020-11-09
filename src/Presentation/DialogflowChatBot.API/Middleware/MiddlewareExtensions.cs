using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace DotNetCore.API.Middleware
{
    public static class MiddlewareExtensions
    {

        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
        public static IApplicationBuilder UseMyHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyHandlerMiddleware>();
        }

        public static IApplicationBuilder UseMyMiddlewareWithParams(this IApplicationBuilder builder, MyMiddlewareOptions myMiddlewareOptions)
        {
            return builder.UseMiddleware<MyMiddlewareWithParams>(new OptionsWrapper<MyMiddlewareOptions>(myMiddlewareOptions));
        }

    }
}
