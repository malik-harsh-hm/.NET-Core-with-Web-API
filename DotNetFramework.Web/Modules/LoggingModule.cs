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
            context.BeginRequest += Application_OnBeginRequest;
            context.EndRequest += Application_OnEndRequest;
        }
        private void Application_OnBeginRequest(object sender, EventArgs e)
        {
            var source = (HttpApplication)sender;
            var startTime = DateTime.Now;
            Debug.WriteLine($"Starting request timer at " +
                $"{startTime} for request " +
                $"{source.Request.Url}");
        }
        private void Application_OnEndRequest(object sender, EventArgs e)
        {
            var source = (HttpApplication)sender;
            var stopTime = DateTime.Now;
            Debug.WriteLine($"Stopping request timer at " +
                $"{stopTime} for request " +
                $"{source.Request.Url}");
        }
        public void Dispose()
        {
        }
    }
}