using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using ApplicationServices.DotNetCore.Handlers;
using ApplicationServices.DotNetCore.Models;
using DotNetCore.API.Configs;
using Domain.DotNetCore.Models;
using Domain.DotNetCore.Repositories;
using Infrastructure.DotNetCore.Repositories;
using Microsoft.Extensions.Configuration;

namespace DotNetCore.API
{
    public class Startup
    {
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
            services.AddMvc();
            services.AddRouting(options => options.LowercaseUrls = true);

            var twilioConfig = new TwilioConfig();
            config.GetSection("TwilioConfig").Bind(twilioConfig);
            services.AddSingleton(twilioConfig);

        }

        private void AddServices(IServiceCollection services)
        {

            services.AddTransient<IHandlesAsync<DefaultQuery, DefaultResponse>, DefaultHandler>();
            services.AddTransient<IDefaultRepository, DefaultRepository>();
        }

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
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
