using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using ApplicationServices.DotNetCore.Handlers;
using ApplicationServices.DotNetCore.Models;
using Domain.DotNetCore.Models;
using Domain.DotNetCore.Repositories;
using Infrastructure.DotNetCore.Repositories;
using Microsoft.Extensions.Configuration;
using DotNetCore.API.Middleware;
using DotNetCore.API.Services;
using DotNetCore.API.Filters;
using System.Diagnostics;
using System;

namespace DotNetCore.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
#if DEBUG
                .AddJsonFile("appsettings.development.json", false)
#endif
                .Build();

            AddServices(services);
            ConfigureScopeTestServices(services);
            services.AddMvc();
            services.AddRouting(options => options.LowercaseUrls = true);

        }

        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<IHandlesAsync<AuthenticationQuery, AuthenticationResponse>, AuthenticationHandler>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<MySampleActionFilter>();

            services.AddScoped<IHandlesAsync<EmployeeQuery, EmployeeResponse>, EmployeeHandler>();
            services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    app.MapWhen(context => context.Request.Path.ToString().EndsWith(".report"),
        //        appbranch =>
        //        {
        //            appbranch.UseMyHandler();
        //        }); // branching pipeline

        //    app.Use(async (context, next) =>
        //    {
        //       await next.Invoke();
        //    }); //in line middleware

        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync("Hello from .Net Core!");
        //    });
        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync("Never Executed");
        //    });
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                var started = context.Response.HasStarted;
                await context.Response.WriteAsync("Hello from .Net Core!");
            });
        }

        public void ConfigureScopeTestServices(IServiceCollection services)
        {
            //services.AddSingleton<ParentService1>();
            //services.AddSingleton<ParentService2>();
            //services.AddSingleton<ChildService>();

            //services.AddTransient<ParentService1>();
            //services.AddTransient<ParentService2>();
            //services.AddTransient<ChildService>();

            //services.AddScoped<ParentService1>();
            //services.AddScoped<ParentService2>();
            //services.AddScoped<ChildService>();

            //------------------------------------------------Mix Cases--------------------------------------------

            // ----------------Mix case 1 - Scoped inside a Singleton

            //won't work -  Cannot consume scoped service 'EmployeeManagement.Services.ChildService' from singleton 'EmployeeManagement.Services.ParentService1'.
            //services.AddSingleton<ParentService1>();
            //services.AddSingleton<ParentService2>();
            //services.AddScoped<ChildService>();

            //solution - make parents as scoped or transient
            //services.AddTransient<ParentService1>();
            //services.AddTransient<ParentService2>();
            //services.AddScoped<ChildService>();

            // -----------------Mix case 2 - Transient inside a Singleton
            //services.AddSingleton<ParentService1>();
            //services.AddSingleton<ParentService2>();
            //services.AddTransient<ChildService>();

            // Below runs but always will have 2 child instances
            //services.AddScoped<ParentService1>();
            //services.AddScoped<ParentService2>();
            //services.AddTransient<ChildService>();


            // -----------------Mix case 3 - Singleton inside a Scoped

            //will work
            services.AddScoped<ParentService1>();
            services.AddScoped<ParentService2>();
            services.AddSingleton<ChildService>();

        }
    }
}
