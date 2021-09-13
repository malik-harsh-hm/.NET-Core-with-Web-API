using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetFramework.Web.Handlers
{
    // ASP.NET 4 handler

        public class MyHandler : IHttpHandler
        {
            public bool IsReusable { get { return true; } }

            public void ProcessRequest(HttpContext context)
            {
                string response = GenerateResponse(context);

                context.Response.ContentType = GetContentType();

                context.Response.Output.Write(response);
            }

            private string GenerateResponse(HttpContext context)
            {
                string title = context.Request.QueryString["title"];
                return string.Format("Title of the report: {0}", title);
            }

            private string GetContentType()
            {
                return "text/plain";
            }
        }
    }
