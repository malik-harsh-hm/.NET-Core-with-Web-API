using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace DotNetFramework.Web.Modules
{
    public class LoggingModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += Application_OnPreRequestHandlerExecute;
            context.EndRequest += Application_OnPostRequestHandlerExecute;
        }
        private void Application_OnPreRequestHandlerExecute(object sender, EventArgs e)
        {
            var source = (HttpApplication)sender;
        }
        private void Application_OnPostRequestHandlerExecute(object sender, EventArgs e)
        {
            var source = (HttpApplication)sender;
        }
        public void Dispose()
        {
        }
    }
}