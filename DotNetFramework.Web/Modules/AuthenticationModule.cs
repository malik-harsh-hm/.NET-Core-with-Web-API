// ASP.NET 4 module

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Web;

namespace DotNetFramework.Web.Modules
{
    public class AuthenticationModule : IHttpModule
    {
        private const string Realm = "Demo";

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(this.Application_AuthenticateRequest);
            context.EndRequest += new EventHandler(this.Application_EndRequest);
        }
        public void Dispose()
        {
         
        }

        private void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;

            var request = context.Request;

            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderval = AuthenticationHeaderValue.Parse(authHeader);
                if (authHeaderval.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderval.Parameter != null)
                {
                    var user = AuthenticateUser(authHeaderval.Parameter);
                    if (user != null)
                    {
                        HttpContext.Current.User = user;
                    }
                    else
                    {
                        HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    }
                }
                else
                {
                    HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
            }
            else
            {
                HttpContext.Current.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
        }
        private void Application_EndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                response.Headers.Add("WWW-Authenticate", $"Basic Realm = {Realm}");
            }
        }

        private GenericPrincipal AuthenticateUser(string credentials)
        {
            var encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            var cred = encoding.GetString(Convert.FromBase64String(credentials));
            int separator = cred.IndexOf(':'); // demo:demo
            string name = cred.Substring(0, separator);
            string password = cred.Substring(separator + 1);
            //Authentication logic here
            if (password == "demo")
            {
                var identity = new GenericIdentity(name);
                return new GenericPrincipal(identity, null);
            }
            return null;
        }

    }
}