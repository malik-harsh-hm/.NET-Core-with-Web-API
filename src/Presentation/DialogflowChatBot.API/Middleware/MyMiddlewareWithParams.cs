using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.API.Middleware
{
    public class MyMiddlewareWithParams
    {
        private readonly RequestDelegate _next;
        private readonly MyMiddlewareOptions _myMiddlewareOptions;

        public MyMiddlewareWithParams(RequestDelegate next, IOptions<MyMiddlewareOptions> optionsAccessor)
        {
            _next = next;
            _myMiddlewareOptions = optionsAccessor.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            // Do something with context near the beginning of request processing
            // using configuration in _myMiddlewareOptions

            await _next.Invoke(context);

            // Do something with context near the end of request processing
            // using configuration in _myMiddlewareOptions
        }
    }
}
