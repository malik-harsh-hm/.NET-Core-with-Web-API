
using ApplicationServices.DotNetCore.Handlers;
using ApplicationServices.DotNetCore.Models;
using Domain.DotNetCore.Models;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading.Tasks;

namespace DotNetCore.API.Middleware
{
    public class AuthenticationMiddleware
    {
        private const string Realm = "Demo";

        private readonly RequestDelegate _next;
        private IHandlesAsync<AuthenticationQuery, AuthenticationResponse> _authenticationHandler;

        public AuthenticationMiddleware(RequestDelegate next)//, IHandlesAsync<AuthenticationQuery, AuthenticationResponse> authenticationHandler)
        {
            _next = next;
            //_authenticationHandler = authenticationHandler;
        }
        // Middleware is always a singleton so you can't have scoped dependencies as constructor dependencies in the constructor of your middleware. 
        // Middleware supports method injection on the Invoke method,
        // so you can just add the IUserRepository as a parameter to that method and it will be injected there and will be fine as scoped.

        public async Task Invoke(HttpContext context, IHandlesAsync<AuthenticationQuery, AuthenticationResponse> authenticationHandler)
        {
            _authenticationHandler = authenticationHandler;

            var request = context.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader.Any())
            {
                var authHeaderval = AuthenticationHeaderValue.Parse(authHeader);
                if (authHeaderval.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderval.Parameter != null)
                {
                    var user = AuthenticateUser(authHeaderval.Parameter);
                    if (user != null)
                    {
                        context.User = user;
                        await _next.Invoke(context);
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    }
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }

            var response = context.Response;
            if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                response.Headers.Add("WWW-Authenticate", $"Basic Realm = {Realm}");
            }
        }

        private GenericPrincipal AuthenticateUser(string credentials)
        {
            var encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            var cred = encoding.GetString(Convert.FromBase64String(credentials));
            int separator = cred.IndexOf(':');
            string name = cred.Substring(0, separator);
            string password = cred.Substring(separator + 1);
            //Authentication logic here

            if (CheckPassword2(name, password).GetAwaiter().GetResult().isAuthenticated)
            {
                var identity = new GenericIdentity(name);
                return new GenericPrincipal(identity, null);
            }
            return null;
        }
        private async Task<AuthenticationResponse> CheckPassword2(string username, string password)
        {

            return await _authenticationHandler.HandleAsync(new AuthenticationQuery { id = username, pwd = password });
        }
    }
}
